using System;
using System.Runtime.Serialization;

namespace ProjectTemplate.WCF.DataTransferObjects
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public virtual Guid? Id { get; set; }

        [DataMember]
        public virtual string Username { get; set; }

        [DataMember]
        public virtual RoleDto Role { get; set; }

        [DataMember]
        public virtual string[] PermissionKeys { get; set; }

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
