using System.Runtime.Serialization;
using System;

namespace ProjectTemplate.WCF.DataTransferObjects
{
    [DataContract]
    public class PermissionRoleDto
    {
        [DataMember]
        public virtual Guid? Id { get; set; }

        [DataMember]
        public virtual PermissionDto Permission { get; set; }

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
