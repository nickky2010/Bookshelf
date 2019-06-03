using System.Collections.Generic;

namespace DAL.Models.Identity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Role)) return false;
            Role r = (Role)obj;
            return Id == r.Id;
        }
        public override int GetHashCode() => Id;
    }
}

