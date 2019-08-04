using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class USB : Component
    {
        public class USBComponent
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<USBComponent> USBProperties { get; set; }

        public USB()
        {
            Key = "Win32_USBController";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Name", "Description" };
            Query = ConstructQuery();
            USBProperties = new List<USBComponent>();
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
                    USBProperties.Add(new USBComponent());
                    int lastIndex = USBProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        USBProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(USBProperties[lastIndex], propData.Value);
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
