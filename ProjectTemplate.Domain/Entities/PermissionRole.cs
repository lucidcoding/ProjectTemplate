using System;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Permission Permission { get; set; }
    }
}
