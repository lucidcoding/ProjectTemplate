using System;
using System.Runtime.Serialization;

namespace ProjectTemplate.WCF.DataTransferObjects
{
    [DataContract]
    public class PermissionDto
    {
        [DataMember]
        public virtual Guid? Id { get; set; }

        [DataMember]
        public virtual string Key { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

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
