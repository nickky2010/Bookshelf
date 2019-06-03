using BLL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class TagDTO : IEntityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter tag name")]
        public string Name { get; set; }
        public virtual ICollection<BookDTO> Books { get; set; }
        public TagDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}
