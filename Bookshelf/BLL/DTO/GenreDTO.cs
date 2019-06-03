using BLL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class GenreDTO : IEntityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter genre name")]
        public string Name { get; set; }
        public virtual ICollection<BookDTO> Books { get; set; }
        public GenreDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}
