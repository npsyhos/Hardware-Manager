using System;
using System.ComponentModel;

namespace HardwareServices
{
    public class OS : SingleComponent
    {
        public OS()
        {
            Key = "Win32_OperatingSystem";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "InstallDate", "Manufacturer", "OSArchitecture", "Version", "LastBootUpTime", "Name" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }

        [DisplayName("OS Name")]
        public string Name { get; private set; }
       
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; private set; }
        [DisplayName("OS Architecture")]
        public string OSArchitecture { get; private set; }
        [DisplayName("Version")]
        public string Version { get; private set; }
        [DisplayName("Install Date")]
        public DateTime InstallDate { get; private set; }
        [DisplayName("Last Booted")]
        public DateTime LastBootUpTime { get; private set; }

        

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}