using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class UserDtoMapper
    {
        public static UserDto Map(User entity)
        {
            var dto = new UserDto();
            dto.Id = entity.Id;
            dto.Username = entity.Username;
            dto.Role = entity.Role != null ? RoleDtoMapper.Map(entity.Role) : null;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }

        public static IEnumerable<UserDto> Map(IEnumerable<User> entities)
        {
            return entities.Select(Map);
        }
    }
}