using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class PermissionRoleDtoMapper
    {
        public static PermissionRoleDto Map(PermissionRole entity)
        {
            var dto = new PermissionRoleDto();
            dto.Id = entity.Id;
            dto.Permission = entity.Permission != null ? PermissionDtoMapper.Map(entity.Permission) : null;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }

        public static IEnumerable<PermissionRoleDto> Map(IEnumerable<PermissionRole> entities)
        {
            return entities.Select(Map);
        }
    }
}