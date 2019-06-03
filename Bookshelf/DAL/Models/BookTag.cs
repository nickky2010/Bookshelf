using System;

namespace DAL.Models
{
    public class BookTag
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookTag)) return false;
            BookTag bt = (BookTag)obj;
            return BookId == bt.BookId & TagId == bt.TagId;
        }
        public override int GetHashCode() => HashCode.Combine(BookId, TagId);
    }
}
