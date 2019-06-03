using BLL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class AuthorDTO : IEntityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter author firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter author lastname")]
        public string LastName { get; set; }
        public virtual ICollection<BookDTO> Books { get; set; }
        public AuthorDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}
