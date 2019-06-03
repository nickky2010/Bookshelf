using System.Collections.Generic;

namespace DAL.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Series()
        {
            Books = new List<Book>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Series)) return false;
            Series s = (Series)obj;
            return Id == s.Id;
        }
        public override int GetHashCode() => Id;
    }
}
