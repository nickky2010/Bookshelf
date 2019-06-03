using System.Collections.Generic;

namespace DAL.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Language()
        {
            Books = new List<Book>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Language)) return false;
            Language l = (Language)obj;
            return Id == l.Id;
        }
        public override int GetHashCode() => Id;
    }
}
