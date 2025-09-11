using System;

namespace ME2Launcher.Models
{
    public class Mod
    {
        public Guid Id { get; set; }

        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Mod()
        {
            Id = Guid.NewGuid();
            Path = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
