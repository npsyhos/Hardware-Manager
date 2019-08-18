using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class RAM : MultipleComponents
    {
        public class RAMComponent : SingleComponent
        {
            [DisplayName("Speed")]
            public UInt32 Speed { get; private set; }
            [DisplayName("Configured Clock Speed")]
            public UInt32 ConfiguredClockSpeed { get; private set; }
            [DisplayName("Size")]
            public string Capacity { get; private set; }
            [DisplayName("Part Number")]
            public string PartNumber { get; private set; }
            [DisplayName("Location")]
            public string DeviceLocator { get; private set; }

            public override string ToString()
            {
                return DeviceLocator;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public RAM() : base(new RAMComponent())
        {
            Key = "Win32_PhysicalMemory";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "PartNumber", "Capacity", "Speed", "ConfiguredClockSpeed", "DeviceLocator" };
            Query = ConstructQuery();
            Components = new List<object>();
            SetPropertyData();
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
