using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Castle.Windsor;
using Lineyschikov.WpfAssignment.Desktop.Views;
using Lineyschikov.WpfAssignment.Desktop.Windsor;

namespace Lineyschikov.WpfAssignment.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IWindsorContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            _container = new WindsorContainer();
            _container.Install(new GuiInstaller());
            var mainWindow = _container.Resolve<IMainWindowView>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _container.Dispose();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Неожидання ошибка: " + e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
