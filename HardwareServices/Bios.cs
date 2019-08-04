namespace HardwareServices
{
    class Bios : Component
    {
        public Bios()
        {
            Key = "Win32_BIOS";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Manufacturer", "Version", "ReleaseDate" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }

        public string Manufacturer { get; set; }
        public string Version { get; set; }
        public string ReleaseDate { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}