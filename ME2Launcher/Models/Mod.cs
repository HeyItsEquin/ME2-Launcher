using System;

namespace ME2Launcher.Models
{
    public class Mod
    {
        Guid Id { get; set; }

        string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        Mod()
        {
            Id = Guid.NewGuid();
            Path = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
