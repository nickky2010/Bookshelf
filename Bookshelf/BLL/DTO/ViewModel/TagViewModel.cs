using BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.ViewModel
{
    public class TagViewModel : IEntityDTO
    {
        [Required(ErrorMessage = "Enter tag id")]
        public int Id { get; set; }
    }
}
