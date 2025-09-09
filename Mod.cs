using System;

namespace ME2Launcher
{
    public class Mod
    {
        string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        Mod()
        {
            Path = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
        }
    }

    public class DllMod
    {
        public string Name { get; set; }
        public string Path { get; set; }

        DllMod()
        {
            Name = string.Empty;
            Path = string.Empty;
        }
    }
}
