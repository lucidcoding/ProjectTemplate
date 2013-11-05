using System;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.Domain.Entities
{
    public class User : Entity<Guid>
    {
        public virtual string Username { get; set; }
        public virtual Role Role { get; set; }
        
        public static User Create(string username, Role role, User currentUser)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Username = username;
            user.Role = role;
            user.CreatedOn = DateTime.Now;
            user.CreatedBy = currentUser;
            return user;
        }
    }
}
