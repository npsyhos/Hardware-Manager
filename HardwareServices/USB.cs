using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class USB : MultipleComponents
    {
        public class USBComponent : SingleComponent
        {
            [DisplayName("Description")]
            public string Description { get; private set; }
            [DisplayName("Name")]
            public string Name { get; private set; }

            public override string ToString()
            {
                return Name;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public USB() : base(new USBComponent())
        {
            Key = "Win32_USBController";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Name", "Description" };
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
