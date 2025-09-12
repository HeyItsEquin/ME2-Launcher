using System;
using System.Windows;
using System.Windows.Threading;
using ME2Launcher.Services;
using ME2Launcher.Tests;

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
            Logger.ClearLog();
            Logger.Info("Initializing database");
            DatabaseService.InitializeDb();
            ProfileService.LoadProfiles();
            Logger.Info($"ProfileService loaded {ProfileService.Profiles.Count} profiles");

            Testing.RunAllTests();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.LogException(e.Exception, "Unhandled Exception");
            Logger.ShowMessageBox(e.Exception.Message, "An unhandled exception occurred");
            e.Handled = true;
        }
    }
}
