using System;
using System.ComponentModel;

namespace HardwareServices
{
    public class Bios : SingleComponent
    {
        public Bios()
        {
            Key = "Win32_BIOS";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Manufacturer", "Version", "ReleaseDate" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }

        [DisplayName("Manufacturer")]
        public string Manufacturer { get; private set; }
        [DisplayName("Version")]
        public string Version { get; private set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; private set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}