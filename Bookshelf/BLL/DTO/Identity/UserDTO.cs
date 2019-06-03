using BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Identity
{
    public class UserDTO: IEntityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        public virtual RoleDTO Role { get; set; }
    }
}
