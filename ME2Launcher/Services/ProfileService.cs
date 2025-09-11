using Tommy;
using ME2Launcher.Models;

namespace ME2Launcher.Services
{
    class ProfileService
    {
        public List<Profile> Profiles { get; set; }

        public ProfileService()
        {
            Profiles = new List<Profile>();
            Logger.Info("Loading profiles from DB");
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            Profiles.Clear();

            var profiles = DatabaseService.GetProfiles();
            if (profiles == null)
            {
                Logger.Warn("DB contains no profiles or failed to load them herein");
                return;
            }

            Profiles.AddRange(profiles);
        }
    }
}
