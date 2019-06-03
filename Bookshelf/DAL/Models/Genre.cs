using System.Collections.Generic;

namespace DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public Genre()
        {
            BookGenres = new List<BookGenre>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Genre)) return false;
            Genre g = (Genre)obj;
            return Id == g.Id;
        }
        public override int GetHashCode() => Id;
    }
}
