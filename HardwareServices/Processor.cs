using System;
using System.ComponentModel;

namespace HardwareServices
{
    public class Processor : SingleComponent
    {
        public Processor()
        {
            Key = "Win32_Processor";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "L2CacheSize", "L3CacheSize", "Name", "SystemName" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }

        [DisplayName("Name")]
        public string Name { get; private set; }
        [DisplayName("L2 Cache Size")]
        public string L2CacheSize { get; private set; }
        [DisplayName("L3 Cache Size")]
        public string L3CacheSize { get; private set; }
        [DisplayName("System Name")]
        public string SystemName { get; private set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}