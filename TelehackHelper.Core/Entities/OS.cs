using System.Collections.Generic;

namespace TelehackHelper.Core.Entities
{
    public class OS
    {
        public string Name { get; set; }


        public static List<OS> OSList = new List<OS>
        {
            new OS { Name = "AIX" },
            new OS { Name = "ATT" },
            new OS { Name = "AUX" },
            new OS { Name = "BSD" },
            new OS { Name = "Dynix" },
            new OS { Name = "HPUX" },
            new OS { Name = "IBM" },
            new OS { Name = "MACH" },
            new OS { Name = "MIL" },
            new OS { Name = "SunOS" },
            new OS { Name = "SysV" },
            new OS { Name = "Ultrix" },
            new OS { Name = "VMS" },
            new OS { Name = "Xenix" }
        };
    }
}
