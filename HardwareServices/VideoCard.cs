using System;
using System.Collections.Generic;

namespace HardwareServices
{
    class VideoCard : MultipleComponents
    {
        public class VideoCardComponent
        {
            public UInt32 MaxRefreshRate { get; set; }
            public UInt32 MinRefreshRate { get; set; }
            public UInt32 CurrentHorizontalResolution { get; set; }
            public UInt32 CurrentVerticalResolution { get; set; }
            public string Name { get; set; }
            public string DriverDate { get; set; }
            public string DriverVersion { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] PropertyNames { get; set; }
        internal override string Query { get; set; }
        public override List<object> DataProperties { get; set; }

        public VideoCard() : base(new VideoCardComponent())
        {
            Key = "Win32_VideoController";

            // Change this to use decorators on the prop names later ?
            PropertyNames = new[] { "Name", "DriverDate", "DriverVersion", "MaxRefreshRate", "MinRefreshRate", "CurrentHorizontalResolution", "CurrentVerticalResolution" };
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
