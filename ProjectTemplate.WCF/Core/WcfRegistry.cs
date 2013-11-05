using ProjectTemplate.Application.Core;
using StructureMap.Configuration.DSL;

namespace ProjectTemplate.WCF.Core
{
    public class WcfRegistry : Registry
    {
        public WcfRegistry()
        {
            Configure(x =>
            {
                x.ImportRegistry(typeof(ApplicationRegistry));
            });
        }
    }
}