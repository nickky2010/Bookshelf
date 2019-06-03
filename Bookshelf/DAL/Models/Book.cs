using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public DateTime DateTimeOfAdded { get; set; }
        public int BookGroupId { get; set; }
        public int LanguageId { get; set; }
        public int PublishingHouseId { get; set; }
        public int? SeriesId { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual BookGroup BookGroup { get; set; }
        public virtual Language Language { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
        public virtual Series Series { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
            BookGenres = new List<BookGenre>();
            BookTags = new List<BookTag>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Book)) return false;
            Book b = (Book)obj;
            return Id == b.Id;
        }
        public override int GetHashCode() => Id;
    }
}
