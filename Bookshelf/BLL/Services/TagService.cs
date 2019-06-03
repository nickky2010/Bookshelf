using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Interfaces.Localizations.Exceptions;
using DAL.EF.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService : IDataBaseService<TagDTO>
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public TagService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }

        public async Task<ICollection<TagDTO>> GetPageAsync(int startItem, int countItem)
        {
            ICollection<TagDTO> tagDTOs = Mapper.Map<ICollection<Tag>, List<TagDTO>>(await UnitOfWork.Tags.GetPageAsync(startItem, countItem));
            if (tagDTOs.Count != 0)
            {
                foreach (TagDTO item in tagDTOs)
                {
                    await FillItem(item);
                }
                return tagDTOs;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.TagsException.NotFound);
        }

        public async Task<TagDTO> GetAsync(int id)
        {
            TagDTO tagDTO = Mapper.Map<Tag, TagDTO>(await UnitOfWork.Tags.GetAsync(i => i.Id == id));
            if (tagDTO != null)
            {
                await FillItem(tagDTO);
                return tagDTO;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.TagsException.NotFoundById(id));
        }

        public async Task<TagDTO> AddAsync(IEntityDTO ientityDTO)
        {
            TagDTO tagDTO = (TagDTO)ientityDTO;
            UnitOfWork.Tags.AddAsync(Mapper.Map<TagDTO, Tag>(tagDTO));
            await UnitOfWork.SaveChangesAsync();
            Tag tag = await UnitOfWork.Tags.GetLastItemAsync();
            if (tag != null)
                return Mapper.Map<Tag, TagDTO>(tag);
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.TagsException.AfterAddNotFound);
        }

        public async Task<TagDTO> UpdateAsync(IEntityDTO ientityDTO)
        {
            TagDTO tagDTO = (TagDTO)ientityDTO;
            Tag tag = await UnitOfWork.Tags.GetAsync(i => i.Id == tagDTO.Id);
            if (tag != null)
            {
                Mapper.Map(tagDTO, tag);
                UnitOfWork.Tags.Update(tag);
                await UnitOfWork.SaveChangesAsync();
                return await GetAsync(tag.Id);
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.TagsException.NotFoundById(tagDTO.Id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Tag tag = await UnitOfWork.Tags.GetAsync(i => i.Id == id);
            if (tag != null)
            {
                UnitOfWork.BookTags.DeleteRange(await UnitOfWork.BookTags.GetAllAsync(t => t.TagId== tag.Id));
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Tags.Delete(tag);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.TagsException.UnableToDelete(id));
        }

        private async Task FillItem(TagDTO tagDTO)
        {
            ICollection<BookTag> bookTags = await UnitOfWork.BookTags.GetAllAsync(i => i.TagId == tagDTO.Id);
            if (bookTags != null)
            {
                foreach (BookTag item in bookTags)
                {
                    tagDTO.Books.Add(Mapper.Map<Book, BookDTO>(await UnitOfWork.Books.GetAsync(i => i.Id == item.BookId)));
                }
            }
        }
    }
}
