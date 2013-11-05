using NHibernate;
using NHibernate.Cfg;
using System.Configuration;

namespace ProjectTemplate.Data.Common
{
    public static class SessionFactoryFactory
    {
        public static ISessionFactory GetSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(SessionFactoryFactory).Assembly.GetName().Name);

            configuration.SetProperty(Environment.ConnectionString,
                ConfigurationManager.ConnectionStrings["ProjectTemplate"].ConnectionString);

            log4net.Config.XmlConfigurator.Configure();
            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}
