using System;

namespace DAL.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookGenre)) return false;
            BookGenre bg = (BookGenre)obj;
            return BookId == bg.BookId & GenreId == bg.GenreId;
        }
        public override int GetHashCode() => HashCode.Combine(BookId, GenreId);
    }
}
