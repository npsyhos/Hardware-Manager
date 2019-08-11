using System.Collections.Generic;

namespace HardwareServices
{
    class Display : MultipleComponents
    {
        public class DisplayComponent
        {
            public string Caption { get; set; }
            public string MonitorType { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public Display() : base(new DisplayComponent())
        {
            Key = "Win32_DesktopMonitor";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Caption", "MonitorType" };
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
