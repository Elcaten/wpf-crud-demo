using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lineyschikov.WpfAssignment.Desktop.DataAccess;
using Lineyschikov.WpfAssignment.Desktop.Services;
using Lineyschikov.WpfAssignment.Desktop.ViewModels;
using Lineyschikov.WpfAssignment.Desktop.Views;

namespace Lineyschikov.WpfAssignment.Desktop.Windsor
{
    public class GuiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register
            (
                Component.For<CoreContext>(),
                Classes.FromAssemblyContaining<IApplicationService>().BasedOn<IApplicationService>(),
                Component.For<IWindsorContainer>().Instance(container),
                Classes.FromThisAssembly().BasedOn<IViewModel>()
                    .WithServiceAllInterfaces(),
                Classes.FromThisAssembly().BasedOn<IView>()
                    .LifestyleTransient()
                    .WithServiceAllInterfaces()
            );
        }
    }
}