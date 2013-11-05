using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.WCF.DataTransferObjects;

namespace ProjectTemplate.WCF.Mappers
{
    public class TaskDtoMapper
    {
        public static TaskDto Map(Task entity)
        {
            var dto = new TaskDto();
            dto.Id = entity.Id;
            dto.Description = entity.Description;
            dto.AssignedTo = entity.AssignedTo != null ? UserDtoMapper.Map(entity.AssignedTo) : null;
            dto.Type = entity.Type != null ? TaskTypeDtoMapper.Map(entity.Type) : null;
            dto.DueDate = entity.DueDate;
            dto.Status = entity.Status;
            dto.RagStatus = entity.RagStatus;
            dto.CreatedOn = entity.CreatedOn;
            dto.LastModifiedOn = entity.LastModifiedOn;
            dto.Deleted = entity.Deleted;
            //todo: don't do LastModifiedBy in here, have a 'MapWithLastModifiedBy' method - otherwise infinately recursive call.
            //todo: don't do CreatedBy in here, have a 'MapWithCreatedBy' method - otherwise infinately recursive call.
            return dto;
        }

        public static IEnumerable<TaskDto> Map(IEnumerable<Task> entities)
        {
            return entities.Select(Map);
        }
    }
}