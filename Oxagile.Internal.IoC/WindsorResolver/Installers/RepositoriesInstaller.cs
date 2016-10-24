using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Oxagile.Internal.IoC.DALCF;
using System.Data.Entity;

namespace Oxagile.Internal.IoC.WindsorResolver.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DbContext>().ImplementedBy<AppContext>().LifeStyle.PerWebRequest);

            container.Register(Classes.FromAssemblyContaining(typeof(BaseRepository<>)).BasedOn(typeof(BaseRepository<>)).WithServiceAllInterfaces().LifestylePerWebRequest());
        }
    }
}