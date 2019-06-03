using BLL.Interfaces;
using System.Collections.Generic;

namespace BLL.DTO.Identity
{
    public class RoleDTO: IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UserDTO> Users { get; set; }
        public RoleDTO()
        {
            Users = new List<UserDTO>();
        }
    }
}

