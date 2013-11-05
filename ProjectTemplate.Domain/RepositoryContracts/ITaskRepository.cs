using System;
using System.Collections.Generic;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enumerations;

namespace ProjectTemplate.Domain.RepositoryContracts
{
    public interface ITaskRepository : IRepository<Task, Guid>
    {
        IList<Task> Search(
            Guid? assignedToId,
            Guid? taskTypeId,
            DateTime? dueDateFrom,
            DateTime? dueDateTo,
            TaskStatus? taskStatus,
            bool? deleted
            );
    }
}
