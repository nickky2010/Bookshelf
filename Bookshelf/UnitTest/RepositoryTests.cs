//using BLL.Infrastructure;
//using DAL.Interfaces;
//using Ninject;
//using System;
//using System.IO;
//using Xunit;
//using System.Linq;
//using DAL.Models;
//using System.Threading.Tasks;
//using System.Threading;

//namespace UnitTest
//{
//    class UnitOfWorkForTests
//    {
//        private static IUnitOfWork unitOfWork;
//        public static IUnitOfWork GetUnitOfWork()
//        {
//            if (unitOfWork == null)
//            {
//                string dir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));
//                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Bookshelf;AttachDbFilename='" + dir + @"DataBase\Bookshelf.mdf';Trusted_Connection=True;";
//                IKernel ninjectKernel = new StandardKernel(new InterfacesRegistrationsBLL(connectionString));
//                unitOfWork = ninjectKernel.Get<IUnitOfWork>();
//            }
//            return unitOfWork;
//        }
//    }
//    public class CreateRepository
//    {
//        IUnitOfWork unitOfWork;
//        public CreateRepository()
//        {
//            this.unitOfWork = UnitOfWorkForTests.GetUnitOfWork();
//        }
//        [Fact]
//        public void BooksRepository()
//        {
//            Assert.NotNull(unitOfWork.Books);
//        }
//        [Fact]
//        public void AuthorsRepository()
//        {
//            Assert.NotNull(unitOfWork.Authors);
//        }
//        [Fact]
//        public void BookAuthorsRepository()
//        {
//            Assert.NotNull(unitOfWork.BookAuthors);
//        }
//        [Fact]
//        public void BookGenresRepository()
//        {
//            Assert.NotNull(unitOfWork.BookGenres);
//        }
//        [Fact]
//        public void BookGroupsRepository()
//        {
//            Assert.NotNull(unitOfWork.BookGroups);
//        }
//        [Fact]
//        public void BookTagsRepository()
//        {
//            Assert.NotNull(unitOfWork.BookTags);
//        }
//        [Fact]
//        public void GenresRepository()
//        {
//            Assert.NotNull(unitOfWork.Genres);
//        }
//        [Fact]
//        public void InformationRepository()
//        {
//            Assert.NotNull(unitOfWork.Information);
//        }
//        [Fact]
//        public void LanguageRepository()
//        {
//            Assert.NotNull(unitOfWork.Languages);
//        }
//        [Fact]
//        public void PublishingHouseRepository()
//        {
//            Assert.NotNull(unitOfWork.PublishingHouses);
//        }
//        [Fact]
//        public void SeriesRepository()
//        {
//            Assert.NotNull(unitOfWork.Series);
//        }
//        [Fact]
//        public void TagsRepository()
//        {
//            Assert.NotNull(unitOfWork.Tags);
//        }
//    }
//    //public class ReadAndVerifyingDataRepository
//    //{
//    //    IUnitOfWork unitOfWork;
//    //    public ReadAndVerifyingDataRepository()
//    //    {
//    //        this.unitOfWork = UnitOfWorkForTests.GetUnitOfWork();
//    //    }
//    //    [Fact]
//    //    public async void BooksRepository()
//    //    {
//    //        Assert.Equal("A meter away from each other", (await unitOfWork.Books.Get(1)).Name);
//    //    }
//    //    [Fact]
//    //    public async void AuthorsRepository()
//    //    {
//    //        Assert.Equal("Dotry", (await unitOfWork.Authors.Get(1)).LastName);
//    //    }
//    //    [Fact]
//    //    public async void BookAuthorsRepository()
//    //    {
//    //        Assert.Equal("Dotry", (await unitOfWork.Books.Get(1)).BookAuthors.Select(ba=>ba.Author).ElementAt(0).LastName);
//    //    }
//    //    [Fact]
//    //    public async void BookGenresRepository()
//    //    {
//    //        Assert.Equal("Novel", (await unitOfWork.Books.Get(1)).BookGenres.Select(ba => ba.Genre).ElementAt(0).Name);
//    //    }
//    //    [Fact]
//    //    public async void BookGroupsRepository()
//    //    {
//    //        Assert.Equal("A meter away from each other", (await unitOfWork.BookGroups.Get(1)).Books.ElementAt(0).Name);
//    //    }
//    //    [Fact]
//    //    public async void BookTagsRepository()
//    //    {
//    //        Assert.Equal("Novel", (await unitOfWork.Books.Get(1)).BookTags.Select(ba => ba.Tag).ElementAt(0).Name);
//    //    }
//    //    [Fact]
//    //    public async void GenresRepository()
//    //    {
//    //        Assert.Equal("Detective", (await unitOfWork.Genres.Get(6)).Name);
//    //    }
//    //    [Fact]
//    //    public async void InformationRepository()
//    //    {
//    //        Assert.Equal(352, (await unitOfWork.Books.Get(1)).Information.Pages);
//    //    }
//    //    [Fact]
//    //    public async void LanguageRepository()
//    //    {
//    //        Assert.Equal("Japanese", (await unitOfWork.Languages.Get(5)).Name);
//    //    }
//    //    [Fact]
//    //    public async void PublishingHouseRepository()
//    //    {
//    //        Assert.Equal("ACT", (await unitOfWork.PublishingHouses.Get(7)).Name);
//    //    }
//    //    [Fact]
//    //    public async void SeriesRepository()
//    //    {
//    //        Assert.Equal("Foreign literature", (await unitOfWork.Series.Get(2)).Name);
//    //    }
//    //    [Fact]
//    //    public async void TagsRepository()
//    //    {
//    //        Assert.Equal("Fantasy", (await unitOfWork.Tags.Get(4)).Name);
//    //    }
//    //}
//    //[CollectionDefinition("Non-Parallel Collection", DisableParallelization = true)]
//    //public class AddAndDeleteDataInRepository
//    //{
//    //    IUnitOfWork unitOfWork;
//    //    public AddAndDeleteDataInRepository()
//    //    {
//    //        this.unitOfWork = UnitOfWorkForTests.GetUnitOfWork();
//    //    }
//    //    [Fact]
//    //    //public async void BooksRepository()
//    //    //{
//    //    //    Book book = new Book
//    //    //    {
//    //    //        Name = "Грокаем алгоритмы", Year = 2019, ISBN = "978-5-4461-0923-4",
//    //    //        Edition = "", DateTimeOfAdded = DateTime.Now.AddMonths(-1).AddDays(-1),
//    //    //        BookGroupId = 1, LanguageId = 1, PublishingHouseId = 1, SeriesId = 1
//    //    //    };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Books.Add(book);
//    //    //        Assert.Equal(book.Name, (await unitOfWork.Books.Get(b => b.ISBN == book.ISBN)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Books.Delete(b => b.ISBN == book.ISBN);
//    //    //        Assert.Null(await unitOfWork.Books.Get(b => b.ISBN == book.ISBN));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void AuthorsRepository()
//    //    //{
//    //    //    Author author = new Author { FirstName = "Адитья", LastName = "Бхаргава" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Authors.Add(author);
//    //    //        Assert.Equal(author.LastName, (await unitOfWork.Authors.Get(a => a.FirstName == author.FirstName)).LastName);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Authors.Delete(a => a.FirstName == author.FirstName);
//    //    //        Assert.Null(await unitOfWork.Authors.Get(b => b.FirstName == author.FirstName));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void BookAuthorsRepository()
//    //    //{
//    //    //    BookAuthor bookAuthor = new BookAuthor { BookId = 1, AuthorId = 5 };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.BookAuthors.Add(bookAuthor);
//    //    //        Assert.Equal("King", (await unitOfWork.Books.Get(1)).BookAuthors.Select(ba => ba.Author).ElementAt(3).LastName);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.BookAuthors.Delete(bookAuthor);
//    //    //        Assert.NotEqual("King", (await unitOfWork.Books.Get(1)).BookAuthors.Select(ba => ba.Author).ElementAt(3).LastName);
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void BookGenresRepository()
//    //    //{
//    //    //    BookGenre bookGenre = new BookGenre { BookId = 1, GenreId = 7 };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.BookGenres.Add(bookGenre);
//    //    //        Assert.Equal("Religion", (await unitOfWork.Books.Get(1)).BookGenres.Select(ba => ba.Genre).ElementAt(1).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.BookGenres.Delete(bookGenre);
//    //    //        Assert.Equal("Religion", (await unitOfWork.Books.Get(1)).BookGenres.Select(ba => ba.Genre).ElementAt(1).Name);
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void BookGroupsRepository()
//    //    //{
//    //    //    BookGroup bookGroup = new BookGroup { Id = 4 };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.BookGroups.Add(bookGroup);
//    //    //        Assert.Equal(bookGroup.Id, (await unitOfWork.BookGroups.Get(a => a.Id == bookGroup.Id)).Id);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Authors.Delete(a => a.Id == bookGroup.Id);
//    //    //        Assert.Null(await unitOfWork.Authors.Get(a => a.Id == bookGroup.Id));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void BookTagsRepository()
//    //    //{
//    //    //    BookTag bookTag = new BookTag { BookId = 1, TagId = 7 };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.BookTags.Add(bookTag);
//    //    //        Assert.Equal("Religion", (await unitOfWork.Books.Get(1)).BookTags.Select(ba => ba.Tag).ElementAt(1).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.BookTags.Delete(bookTag);
//    //    //        Assert.Equal("Religion", (await unitOfWork.Books.Get(1)).BookTags.Select(ba => ba.Tag).ElementAt(1).Name);
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void GenresRepository()
//    //    //{
//    //    //    Genre genre = new Genre { Name = "Development" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Genres.Add(genre);
//    //    //        Assert.Equal(genre.Name, (await unitOfWork.Genres.Get(g => g.Name == genre.Name)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Genres.Delete(a => a.Name == genre.Name);
//    //    //        Assert.Null(await unitOfWork.Genres.Get(a => a.Name == genre.Name));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}

//    //    //[Fact]
//    //    //public async void InformationRepository()
//    //    //{
//    //    //    Information information = new Information { BookId = 2, Height = 999, Pages = 999999, Weight = 999, Width = 999 };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Information.Add(information);
//    //    //        Assert.Equal("Lethal White", (await unitOfWork.Information.Get(i => i.Pages == information.Pages)).Book.Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Information.Delete(i => i.Pages == information.Pages);
//    //    //        Assert.Null(await unitOfWork.Information.Get(i => i.Pages == information.Pages));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void LanguageRepository()
//    //    //{
//    //    //    Language language = new Language { Name = "Kyrgyz" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Languages.Add(language);
//    //    //        Assert.Equal(language.Name, (await unitOfWork.Languages.Get(l => l.Name == language.Name)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Languages.Delete(l => l.Name == language.Name);
//    //    //        Assert.Null(await unitOfWork.Languages.Get(l => l.Name == language.Name));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void PublishingHouseRepository()
//    //    //{
//    //    //    PublishingHouse publishingHouse = new PublishingHouse { Name = "Roga and Kopita ltd" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.PublishingHouses.Add(publishingHouse);
//    //    //        Assert.Equal(publishingHouse.Name, (await unitOfWork.PublishingHouses.Get(p => p.Name == publishingHouse.Name)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.PublishingHouses.Delete(p => p.Name == publishingHouse.Name);
//    //    //        Assert.Null(await unitOfWork.PublishingHouses.Get(p => p.Name == publishingHouse.Name));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void SeriesRepository()
//    //    //{
//    //    //    Series series = new Series { Name = "C#" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Series.Add(series);
//    //    //        Assert.Equal(series.Name, (await unitOfWork.Series.Get(s => s.Name == series.Name)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Series.Delete(s => s.Name == series.Name);
//    //    //        Assert.Null(await unitOfWork.Series.Get(s => s.Name == series.Name));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //    //[Fact]
//    //    //public async void TagsRepository()
//    //    //{
//    //    //    Tag tag = new Tag { Name = "C#" };
//    //    //    async void Add()
//    //    //    {
//    //    //        unitOfWork.Tags.Add(tag);
//    //    //        Assert.Equal(tag.Name, (await unitOfWork.Tags.Get(t => t.Name == tag.Name)).Name);
//    //    //    }
//    //    //    async void Del()
//    //    //    {
//    //    //        unitOfWork.Tags.Delete(t => t.Name == tag.Name);
//    //    //        Assert.Null(await unitOfWork.Tags.Get(t => t.Name == tag.Name));
//    //    //    }
//    //    //    await Task.Run(() => Add());
//    //    //    await Task.Run(() => Del());
//    //    //}
//    //}
//}
