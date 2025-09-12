using ME2Launcher.Models;
using ME2Launcher.Services;

namespace ME2Launcher.Tests
{
    public static class Testing
    {
        public static void RunAllTests()
        {
            TestDatabaseService();
            TestProfileService();
        }

        public static void TestDatabaseService()
        {
            var profiles = DatabaseService.GetProfiles();
            var mods = DatabaseService.GetMods();
            var dlls = DatabaseService.GetDllMods();

            Logger.Info($"Loaded {profiles.Count} profiles from DB");
            Logger.Info($"Loaded {mods.Count} mods from DB");
            Logger.Info($"Loaded {dlls.Count} DLL mods from DB");
        }

        public static void TestProfileService()
        {
            Logger.Info($"ProfileService loaded {ProfileService.Profiles.Count} profiles");
        }
    }
}
