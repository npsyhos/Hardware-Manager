using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class StorageDrives : MultipleComponents
    {
        public class StorageComponent
        {
            public UInt32 Partitions { get; set; }
            public UInt64 Size { get; set; }
            public string Model { get; set; }
            public string SerialNumber { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public StorageDrives() : base(new StorageComponent())
        {
            Key = "Win32_DiskDrive";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Model", "Size", "SerialNumber", "Partitions" };
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
