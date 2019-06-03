using System.Collections.Generic;

namespace DAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Author)) return false;
            Author a = (Author)obj;
            return Id == a.Id;
        }
        public override int GetHashCode() => Id;
    }
}
