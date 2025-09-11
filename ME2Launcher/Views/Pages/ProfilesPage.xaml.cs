using System;
using System.Windows.Controls;
using ME2Launcher.ViewModels;

namespace ME2Launcher.Views.Pages
{
    /// <summary>
    /// Interaction logic for ProfilesPage.xaml
    /// </summary>
    public partial class ProfilesPage : Page
    {
        public ProfilesPage()
        {
            InitializeComponent();

            DataContext = new ProfilesViewModel();
        }
    }
}
