using System;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using ProjectTemplate.Data.Common;
using ProjectTemplate.UI.Common;
using ProjectTemplate.UI.Core;
using StructureMap;

namespace ProjectTemplate.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    //TODO: put last line error logging in.
    //todo: need to include release transforms?
    //todo: include stuff for dbdeploy.

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //TOdo: research this:
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Task", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //TODO: have global session factory.
            SessionFactory = SessionFactoryFactory.GetSessionFactory();

            AreaRegistration.RegisterAllAreas();
            ObjectFactory.Container.Configure(x => x.AddRegistry<UiRegistry>());
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerActivator());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        void Application_Error(object sender, EventArgs e)
        {

        }
    }
}