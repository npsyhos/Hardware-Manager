using System.Collections.Generic;

namespace HardwareServices
{
    class USB : MultipleComponents
    {
        public class USBComponent
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public USB() : base(new USBComponent())
        {
            Key = "Win32_USBController";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Name", "Description" };
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
