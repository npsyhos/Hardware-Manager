using System;

namespace HardwareServices
{
    class Processor : SingleComponent
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

        public UInt32 L2CacheSize { get; set; }
        public UInt32 L3CacheSize { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}