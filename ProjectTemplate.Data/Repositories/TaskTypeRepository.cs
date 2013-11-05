using System;
using NHibernate;
using ProjectTemplate.Data.Common;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.RepositoryContracts;

namespace ProjectTemplate.Data.Repositories
{
    public class TaskTypeRepository : Repository<TaskType, Guid>, ITaskTypeRepository
    {
        public TaskTypeRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }
    }
}
