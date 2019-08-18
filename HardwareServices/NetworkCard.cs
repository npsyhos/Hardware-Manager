using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class NetworkCard : MultipleComponents
    {
        public class ComponentData : SingleComponent
        {
            [DisplayName("Manufacturer")]
            public string Manufacturer { get; private set; }
            [DisplayName("Name")]
            public string Name { get; private set; }
            [DisplayName("Adapter Type")]
            public string AdapterType { get; private set; }
            [DisplayName("MAC Address")]
            public string MACAddress { get; private set; }
            [DisplayName("Network Connection ID")]
            public string NetConnectionID { get; private set; }

            public override string ToString()
            {
                return Name;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public NetworkCard() : base(new ComponentData())
        {
            Key = "Win32_NetworkAdapter";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Manufacturer", "Name", "AdapterType", "MACAddress", "NetConnectionID" };
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