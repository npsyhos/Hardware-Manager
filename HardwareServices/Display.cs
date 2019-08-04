using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class Display : Component
    {
        public class DisplayComponent
        {
            public string Caption { get; set; }
            public string MonitorType { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<DisplayComponent> DisplayProperties { get; set; }

        public Display()
        {
            Key = "Win32_DesktopMonitor";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Caption", "MonitorType" };
            Query = ConstructQuery();
            DisplayProperties = new List<DisplayComponent>();
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
                    DisplayProperties.Add(new DisplayComponent());
                    int lastIndex = DisplayProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        DisplayProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(DisplayProperties[lastIndex], propData.Value);
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
