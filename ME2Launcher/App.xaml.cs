using System;
using System.Windows;
using System.Windows.Threading;
using ME2Launcher.Services;

namespace ME2Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Logger.Info("Application starting");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Logger.Info("Initializing database");
            DatabaseService.InitializeDb();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.LogException(e.Exception, "Unhandled Exception");
            Logger.ShowMessageBox(e.Exception.Message, "An unhandled exception occurred");
            e.Handled = true;
        }
    }
}
