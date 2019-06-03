namespace DAL.Models.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User)) return false;
            User u = (User)obj;
            return Id == u.Id;
        }
        public override int GetHashCode() => Id;
    }
}
