using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class RoleDtoMapper
    {
        public static RoleDto Map(Role entity)
        {
            var dto = new RoleDto();
            dto.Id = entity.Id;
            dto.RoleName = entity.RoleName;
            dto.Description = entity.Description;
            dto.PermissionRoles = entity.PermissionRoles != null ? PermissionRoleDtoMapper.Map(entity.PermissionRoles).ToArray() : null;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }
    }
}