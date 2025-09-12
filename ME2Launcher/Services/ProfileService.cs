using Tommy;
using ME2Launcher.Models;

namespace ME2Launcher.Services
{
    public static class ProfileService
    {
        public static List<Profile> Profiles { get; set; }

        public static void LoadProfiles()
        {
            if (Profiles == null)
            {
                Profiles = new List<Profile>();
            }
            Profiles.Clear();

            var profiles = DatabaseService.GetProfiles();
            if (profiles == null || profiles.Count == 0)
            {
                Logger.Warn("DB contains no profiles or failed to load them herein");
                return;
            }

            Profiles.AddRange(profiles);
        }
    }
}
