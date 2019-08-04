using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class StorageDrives : Component
    {
        public class StorageComponent
        {
            public string Model { get; set; }
            public UInt64 Size { get; set; }
            public string SerialNumber { get; set; }
            public UInt32 Partitions { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<StorageComponent> StorageProperties { get; set; }

        public StorageDrives()
        {
            Key = "Win32_DiskDrive";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Model", "Size", "SerialNumber", "Partitions" };
            Query = ConstructQuery();
            StorageProperties = new List<StorageComponent>();
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
                    StorageProperties.Add(new StorageComponent());
                    int lastIndex = StorageProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        StorageProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(StorageProperties[lastIndex], propData.Value);
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
