using System.ComponentModel;

namespace HardwareServices
{
    public class Motherboard : SingleComponent
    {
        public Motherboard()
        {
            Key = "Win32_BaseBoard";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Manufacturer", "Product" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }

        [DisplayName("Manufacturer")]
        public string Manufacturer { get; private set; }
        [DisplayName("Model")]
        public string Product { get; private set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}