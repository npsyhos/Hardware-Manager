using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class RAM : MultipleComponents
    {
        public class RAMComponent
        {
            public UInt32 Speed { get; set; }
            public UInt32 ConfiguredClockSpeed { get; set; }
            public UInt64 Capacity { get; set; }
            public string PartNumber { get; set; }
            public string DeviceLocator { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public RAM() : base(new RAMComponent())
        {
            Key = "Win32_PhysicalMemory";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "PartNumber", "Capacity", "Speed", "ConfiguredClockSpeed", "DeviceLocator" };
            Query = ConstructQuery();
            DataProperties = new List<object>();
            SetPropertyData();
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
