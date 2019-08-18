using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class StorageDrives : MultipleComponents
    {
        public class StorageComponent : SingleComponent
        {
            
            [DisplayName("Size")]
            public string Size { get; private set; }
            [DisplayName("Number of Partitions")]
            public UInt32 Partitions { get; private set; }
            [DisplayName("Serial Number")]
            public string SerialNumber { get; private set; }
            [DisplayName("Model")]
            public string Model { get; private set; }

            public override string ToString()
            {
                return Model;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public StorageDrives() : base(new StorageComponent())
        {
            Key = "Win32_DiskDrive";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Model", "Size", "SerialNumber", "Partitions" };
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
