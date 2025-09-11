using System;
using System.Collections.ObjectModel;
using ME2Launcher.Models;
using ME2Launcher.Services;

namespace ME2Launcher.ViewModels
{
    class ProfilesViewModel
    {
        public ObservableCollection<Profile> Profiles { get; set; }

        public ProfilesViewModel()
        {
            try
            {
                Profiles = new ObservableCollection<Profile>(DatabaseService.GetProfiles());
            } catch(Exception e)
            {
                var box = new Wpf.Ui.Controls.MessageBox();
                box.Title = "Database Error";
                box.Content = e.Message;
                box.CloseButtonText = "Ok";
                box.ShowDialogAsync();
                Profiles = new ObservableCollection<Profile>();
            }
        }
    }
}
