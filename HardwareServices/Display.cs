using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class Display : MultipleComponents
    {
        public class DisplayComponent : SingleComponent
        {
            [DisplayName("Caption")]
            public string Caption { get; private set; }
            [DisplayName("Monitor Type")]
            public string MonitorType { get; private set; }

            public override string ToString()
            {
                return Caption;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public Display() : base(new DisplayComponent())
        {
            Key = "Win32_DesktopMonitor";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Caption", "MonitorType" };
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
