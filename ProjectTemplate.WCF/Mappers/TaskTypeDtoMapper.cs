using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class TaskTypeDtoMapper
    {
        public static TaskTypeDto Map(TaskType entity)
        {
            var dto = new TaskTypeDto();
            dto.Id = entity.Id;
            dto.Description = entity.Description;
            dto.ServiceLevelAgreementMinutes = entity.ServiceLevelAgreementMinutes;
            dto.WarningWindowMinutes = entity.WarningWindowMinutes;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }

        public static IEnumerable<TaskTypeDto> Map(IEnumerable<TaskType> entities)
        {
            return entities.Select(Map);
        }
    }
}