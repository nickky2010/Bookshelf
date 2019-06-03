using System.Collections.Generic;

namespace DAL.Models
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public PublishingHouse()
        {
            Books = new List<Book>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PublishingHouse)) return false;
            PublishingHouse p = (PublishingHouse)obj;
            return Id == p.Id;
        }
        public override int GetHashCode() => Id;
    }
}
