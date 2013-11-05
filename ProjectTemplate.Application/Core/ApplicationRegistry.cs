using log4net;
using ProjectTemplate.Application.Contracts;
using ProjectTemplate.Application.Implementations;
using ProjectTemplate.Data.Core;
using StructureMap.Configuration.DSL;

namespace ProjectTemplate.Application.Core
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Configure(x =>
            {
                For<IUserService>().Use<UserService>();
                For<ITaskService>().Use<TaskService>();
                For<ILog>().Use(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
                x.ImportRegistry(typeof(DataRegistry));
            });
        }
    }
}
