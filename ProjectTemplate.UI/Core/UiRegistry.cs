using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using ProjectTemplate.Application.Core;
using ProjectTemplate.UI.ActionFilters;
using ProjectTemplate.UI.Common;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ProjectTemplate.UI.Core
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            Configure(x =>
                      {
                          x.ImportRegistry(typeof(ApplicationRegistry));
                          For<ISessionFactory>().Use(MvcApplication.SessionFactory);

                          //For<IUserLoginProvider>().Use<HttpContextUserLoginProvider>();

                          //For<IViewEngine>().Use<RazorViewEngine>();
                          //SetAllProperties(p => p.OfType<ISessionFactory>());
                          //FillAllPropertiesOfType<ISessionFactory>();

                      });

        }
    }
}