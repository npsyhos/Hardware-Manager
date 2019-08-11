using System.Collections.Generic;

namespace HardwareServices
{
    class NetworkCard : MultipleComponents
    {
        public class ComponentData
        {
            public string Manufacturer { get; set; }
            public string Name { get; set; }
            public string AdapterType { get; set; }
            public string MACAddress { get; set; }
            public string NetConnectionID { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public NetworkCard() : base(new ComponentData())
        {
            Key = "Win32_NetworkAdapter";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Manufacturer", "Name", "AdapterType", "MACAddress", "NetConnectionID" };
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