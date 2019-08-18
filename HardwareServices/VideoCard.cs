using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HardwareServices
{
    public class VideoCard : MultipleComponents
    {
        public class VideoCardComponent : SingleComponent
        {
            [DisplayName("Name")]
            public string Name { get; private set; }
            [DisplayName("Driver Version")]
            public string DriverVersion { get; private set; }
            [DisplayName("Driver Date")]
            public DateTime DriverDate { get; private set; }
            [DisplayName("Horizontal Resolution")]
            public string CurrentHorizontalResolution { get; private set; }
            [DisplayName("Vertical Resolution")]
            public string CurrentVerticalResolution { get; private set; }
            [DisplayName("Maximum Refresh Rate")]
            public string MaxRefreshRate { get; private set; }
            [DisplayName("Minimum Refresh Rate")]
            public string MinRefreshRate { get; private set; }

            public override string ToString()
            {
                return Name;
            }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> Components { get; set; }

        public VideoCard() : base(new VideoCardComponent())
        {
            Key = "Win32_VideoController";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Name", "DriverDate", "DriverVersion", "MaxRefreshRate", "MinRefreshRate", "CurrentHorizontalResolution", "CurrentVerticalResolution" };
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
