using System;
using System.Runtime.Serialization;

using ProjectTemplate.Domain.Enumerations;

namespace ProjectTemplate.WCF.DataTransferObjects
{
    [DataContract]
    public class TaskDto
    {
        [DataMember]
        public virtual Guid? Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public UserDto AssignedTo { get; set; }

        [DataMember]
        public TaskTypeDto Type { get; set; }

        [DataMember]
        public DateTime DueDate { get; set; }

        [DataMember]
        public TaskStatus Status { get; set; }

        [DataMember]
        public RagStatus RagStatus { get; set; }

        [DataMember]
        public virtual UserDto CreatedBy { get; set; }

        [DataMember]
        public virtual DateTime? CreatedOn { get; set; }

        [DataMember]
        public virtual bool Deleted { get; set; }

        [DataMember]
        public virtual UserDto LastModifiedBy { get; set; }

        [DataMember]
        public virtual DateTime? LastModifiedOn { get; set; }
    }
}