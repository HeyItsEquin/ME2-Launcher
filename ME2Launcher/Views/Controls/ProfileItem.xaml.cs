using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ME2Launcher.Views.Controls
{
    /// <summary>
    /// Interaction logic for ProfileItem.xaml
    /// </summary>
    public partial class ProfileItem : UserControl
    {
        public ProfileItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ProfileNameProperty =
            DependencyProperty.Register(
                "ProfileName",
                typeof(string),
                typeof(ProfileItem),
                new PropertyMetadata(string.Empty)
            );

        public static readonly DependencyProperty ProfileDescriptionProperty =
            DependencyProperty.Register(
                "ProfileDescription",
                typeof(string),
                typeof(ProfileItem),
                new PropertyMetadata(string.Empty)
            );

        public static readonly DependencyProperty ProfileIdProperty =
            DependencyProperty.Register(
                "ProfileId",
                typeof(Guid),
                typeof(ProfileItem),
                new PropertyMetadata(Guid.Empty)
            );

        public string ProfileName
        {
            get { return (string)GetValue(ProfileNameProperty); }
            set { SetValue(ProfileNameProperty, value); }
        }

        public string ProfileDescription
        {
            get { return (string)GetValue(ProfileDescriptionProperty); }
            set { SetValue(ProfileDescriptionProperty, value); }
        }

        public string ProfileId
        {
            get { return (string)GetValue(ProfileIdProperty); }
            set { SetValue(ProfileIdProperty, value); }
        }
    }
}
