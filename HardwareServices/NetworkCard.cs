using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class NetworkCard : Component
    {
        public class CardComponent
        {
            public string Manufacturer { get; set; }
            public string Name { get; set; }
            public string AdapterType { get; set; }
            public string MACAddress { get; set; }
            public string NetConnectionID { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<CardComponent> CardProperties { get; set; }

        public NetworkCard()
        {
            Key = "Win32_NetworkAdapter";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Manufacturer", "Name", "AdapterType", "MACAddress", "NetConnectionID" };
            Query = ConstructQuery();
            CardProperties = new List<CardComponent>();
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
                    CardProperties.Add(new CardComponent());
                    int lastIndex = CardProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        CardProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(CardProperties[lastIndex], propData.Value);
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