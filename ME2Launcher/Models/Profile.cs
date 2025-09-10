using System;

namespace ME2Launcher.Models
{
    public class Profile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Mod> ModList { get; set; }
        public List<DllMod> DllMods { get; set; }

        Profile()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            ModList = new List<Mod>();
            DllMods = new List<DllMod>();
        }
    }
}
