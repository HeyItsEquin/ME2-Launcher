using System;
using System.Diagnostics;

namespace ME2Launcher
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

        public bool ConfigFileExists()
        {
            return System.IO.Path.Exists($"Internal/Profiles/{Name}/config.toml");
        }

        public void CreateConfigFile()
        {
            ConfigGenerator.GenerateConfigFile(this, ConfigPath());
        }

        public string ConfigPath()
        {
            return $"Internal/Profiles/{Name}/config.toml";
        }

        public void CreateME2Process()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "Internal/ModEngine2/modengine2_launcher.exe";
            proc.StartInfo.Arguments = $"-t er -c {ConfigPath()}";
            proc.Start();
        }

        public void Run()
        {
            if(!ConfigFileExists())
            {
                CreateConfigFile();
            }
            CreateME2Process();
        }
    }
}
