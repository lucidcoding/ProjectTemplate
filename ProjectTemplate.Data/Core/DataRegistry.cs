using ProjectTemplate.Data.Repositories;
using ProjectTemplate.Domain.RepositoryContracts;
using StructureMap.Configuration.DSL;

namespace ProjectTemplate.Data.Core
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Configure(x =>
            {
                For<IUserRepository>().Use<UserRepository>();
                For<IRoleRepository>().Use<RoleRepository>();
                For<ITaskRepository>().Use<TaskRepository>();
                For<ITaskTypeRepository>().Use<TaskTypeRepository>();
            });
        }
    }
}
