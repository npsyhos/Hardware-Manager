namespace HardwareServices
{
    class OS : SingleComponent
    {
        public OS()
        {
            Key = "Win32_OperatingSystem";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "InstallDate", "Manufacturer", "OSArchitecture", "Version", "LastBootUpTime", "Name" };
            Query = ConstructQuery();
            SetPropertyData();
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }

        public string InstallDate { get; set; }
        public string Manufacturer { get; set; }
        public string OSArchitecture { get; set; }
        public string Version { get; set; }
        public string LastBootUpTime { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}