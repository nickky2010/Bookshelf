using System.Collections.Generic;

namespace DAL.Models
{
    public class BookGroup
    {
        public int Id { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public BookGroup()
        {
            Books = new List<Book>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookGroup)) return false;
            BookGroup bg = (BookGroup)obj;
            return Id == bg.Id;
        }
        public override int GetHashCode() => Id;
    }
}
