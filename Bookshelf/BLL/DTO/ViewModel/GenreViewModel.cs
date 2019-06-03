using BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.ViewModel
{
    public class GenreViewModel : IEntityDTO
    {
        [Required(ErrorMessage = "Enter genre id")]
        public int Id { get; set; }
    }
}
