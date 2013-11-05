using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class PermissionDtoMapper
    {
        public static PermissionDto Map(Permission entity)
        {
            var dto = new PermissionDto();
            dto.Id = entity.Id;
            dto.Description = entity.Description;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }

        public static IEnumerable<PermissionDto> Map(IEnumerable<Permission> entities)
        {
            return entities.Select(Map);
        }
    }
}