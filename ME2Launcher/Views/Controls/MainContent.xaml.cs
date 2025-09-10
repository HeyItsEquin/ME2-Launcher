using System;
using System.Windows;
using System.Windows.Controls;
using ME2Launcher.Views.Pages;

namespace ME2Launcher.Views.Controls
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        public MainContent()
        {
            InitializeComponent();
            Loaded += MainContent_Loaded;
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            RootNav.Navigate(typeof(HomePage));
        }
    }
}
