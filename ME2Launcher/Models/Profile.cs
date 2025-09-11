using System;

namespace ME2Launcher.Models
{
    public class Profile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Mod> ModList { get; set; }
        public List<Dll> DllMods { get; set; }

        public Profile()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            ModList = new List<Mod>();
            DllMods = new List<Dll>();
        }
    }
}
