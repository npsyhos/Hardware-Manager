using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class RAM : Component
    {
        public class RAMComponent
        {
            public string PartNumber { get; set; }
            public UInt64 Capacity { get; set; }
            public UInt32 Speed { get; set; }
            public UInt32 ConfiguredClockSpeed { get; set; }
            public string DeviceLocator { get; set; }

        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<RAMComponent> RAMProperties { get; set; }

        public RAM()
        {
            Key = "Win32_PhysicalMemory";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "PartNumber", "Capacity", "Speed", "ConfiguredClockSpeed", "DeviceLocator" };
            Query = ConstructQuery();
            RAMProperties = new List<RAMComponent>();
            SetPropertyData();
        }

        internal override void SetPropertyData()
        {
            // Get the property information on the piece of hardware
            ManagementObjectCollection managementObj = ExecuteQuery();
            // Set the list of property data
            if (managementObj != null)
            {
                foreach (ManagementObject managementObject in managementObj)
                {
                    RAMProperties.Add(new RAMComponent());
                    int lastIndex = RAMProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        RAMProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(RAMProperties[lastIndex], propData.Value);
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
