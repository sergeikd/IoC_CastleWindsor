using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Oxagile.Internal.IoC.BL;
using Oxagile.Internal.IoC.Notification;
using System.Web.Mvc;

namespace Oxagile.Internal.IoC.WindsorResolver.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<INotificator>()
                    .Named("SmsNotificator")
                    .ImplementedBy<SmsNotificator>()
                    .LifeStyle.Transient);
            container.Register(
                Component.For<INotificator>()
                    .Named("EmailNotificator")
                    .ImplementedBy<EmailNotificator>()
                    .LifeStyle.Transient);
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorActionInvoker>().LifeStyle.Transient);

            container.Register(Component.For<ITestService>().ImplementedBy<TestService>().LifeStyle.PerWebRequest);
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog)
                    .WithConfig("NLog.config"));
        }
    }
}