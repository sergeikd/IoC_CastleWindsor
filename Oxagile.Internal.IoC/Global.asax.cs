using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Oxagile.Internal.IoC.DALCF;
using Oxagile.Internal.IoC.WindsorResolver;

namespace Oxagile.Internal.IoC
{
    //https://github.com/castleproject/Windsor/blob/master/docs/mvc-tutorial-part-4-putting-it-all-together.md
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {

            BootstrapContainer();
            Database.SetInitializer(new EntitiesDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}