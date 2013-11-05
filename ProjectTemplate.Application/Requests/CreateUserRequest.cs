using System;

namespace ProjectTemplate.Application.Requests
{
    public class CreateUserRequest
    {
        public string NewUsername { get; set; }
        public Guid? RoleId { get; set; }
        public string ActioningUserName { get; set; }
    }
}
