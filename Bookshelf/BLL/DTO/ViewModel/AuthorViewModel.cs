using BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.ViewModel
{
    public class AuthorViewModel : IEntityDTO
    {
        [Required(ErrorMessage = "Enter author id")]
        public int Id { get; set; }
    }
}
