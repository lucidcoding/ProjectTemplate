using System;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.Domain.Entities
{
    public class Permission : Entity<Guid>
    {
        public virtual string Description { get; set; }
    }
}
