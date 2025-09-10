using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ME2Launcher.Models
{
    public class Dll
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public Dll()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            FilePath = string.Empty;
        }
    }
}
