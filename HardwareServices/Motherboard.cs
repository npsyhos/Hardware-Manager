namespace HardwareServices
{
    class Motherboard : SingleComponent
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

        public string Manufacturer { get; set; }
        public string Product { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}