using System;

namespace DAL.Models
{
    public class BookInformation
    {
        public int Id { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public int Pages { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookInformation)) return false;
            BookInformation bi = (BookInformation)obj;
            return Id == bi.Id;
        }
        public override int GetHashCode() => Id;
    }
}
