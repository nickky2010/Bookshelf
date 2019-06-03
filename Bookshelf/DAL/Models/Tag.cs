using System.Collections.Generic;

namespace DAL.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
        public Tag()
        {
            BookTags = new List<BookTag>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Tag)) return false;
            Tag t = (Tag)obj;
            return Id == t.Id;
        }
        public override int GetHashCode() => Id;
    }
}
