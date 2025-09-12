using ME2Launcher.Models;

namespace ME2Launcher.Services
{
    public static class ModService
    {
        public static List<Mod> Mods { get; set; }

        public static void LoadMods()
        {
            if(Mods == null)
            {
                Mods = new List<Mod>();
            }
            Mods.Clear();
            var mods = DatabaseService.GetMods();
            if (mods == null || mods.Count == 0)
            {
                Logger.Warn("DB contains no mods or failed to load them herein");
                return;
            }
            Mods.AddRange(mods);
        }

        public static Mod GetModFromId(Guid id)
        {
            if (Mods == null || Mods.Count == 0)
            {
                LoadMods();
            }
            var mod = Mods.Find(m => m.Id == id);
            if (mod == null)
            {
                Logger.Warn($"Could not find mod with id {id}");
                return new Mod();
            }
            return mod;
        }
    }
}
