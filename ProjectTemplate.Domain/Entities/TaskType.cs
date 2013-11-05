using System;
using System.Runtime.Serialization;
using ProjectTemplate.Domain.Common;

namespace ProjectTemplate.Domain.Entities
{
    public class TaskType : Entity<Guid>
    {
        public virtual string Description { get; set; }
        public virtual int ServiceLevelAgreementMinutes { get; set; }
        public virtual int WarningWindowMinutes { get; set; }
    }
}
