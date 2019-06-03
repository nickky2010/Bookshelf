using System;

namespace DAL.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookAuthor)) return false;
            BookAuthor ba = (BookAuthor)obj;
            return BookId == ba.BookId & AuthorId == ba.AuthorId;
        }
        public override int GetHashCode() => HashCode.Combine(BookId, AuthorId);

    }
}
