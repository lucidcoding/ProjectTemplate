using System;
using ProjectTemplate.Domain.Common;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Domain.RepositoryContracts
{
    public interface ITaskTypeRepository : IRepository<TaskType, Guid>
    {
    }
}
