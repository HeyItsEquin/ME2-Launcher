using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME2Launcher.Models;

namespace ME2Launcher.Services
{
    public static class DllService
    {
        public static List<Dll> Dlls { get; set; }

        public static void LoadMods()
        {
            if (Dlls == null)
            {
                Dlls = new List<Dll>();
            }
            Dlls.Clear();
            var dlls = DatabaseService.GetDllMods();
            if (dlls == null || dlls.Count == 0)
            {
                Logger.Warn("DB contains no DLL mods or failed to load them herein");
                return;
            }
            Dlls.AddRange(dlls);
        }

        public static Dll GetDllFromId(Guid id)
        {
            if (Dlls == null || Dlls.Count == 0)
            {
                LoadMods();
            }
            var dll = Dlls.Find(d => d.Id == id);
            if (dll == null)
            {
                Logger.Warn($"Could not find DLL mod with id {id}");
                return new Dll();
            }
            return dll;
        }
    }
}
