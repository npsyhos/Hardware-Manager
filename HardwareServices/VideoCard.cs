using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class VideoCard : Component
    {
        public class VideoCardComponent
        {
            public string Name { get; set; }
            public string DriverDate { get; set; }
            public string DriverVersion { get; set; }
            public UInt32 MaxRefreshRate { get; set; }
            public UInt32 MinRefreshRate { get; set; }
            public UInt32 CurrentHorizontalResolution { get; set; }
            public UInt32 CurrentVerticalResolution { get; set; }
        }

        internal override string Key { get; set; }
        internal override string[] ColumnNames { get; set; }
        internal override string Query { get; set; }
        public List<VideoCardComponent> VideoCardProperties { get; set; }

        public VideoCard()
        {
            Key = "Win32_VideoController";

            // Change this to use decorators on the prop names later ?
            ColumnNames = new[] { "Name", "DriverDate", "DriverVersion", "MaxRefreshRate", "MinRefreshRate", "CurrentHorizontalResolution", "CurrentVerticalResolution" };
            Query = ConstructQuery();
            VideoCardProperties = new List<VideoCardComponent>();
            SetPropertyData();
        }

        internal override void SetPropertyData()
        {
            // Get the property information on the piece of hardware
            ManagementObjectCollection managementObj = ExecuteQuery();
            // Set the list of property data
            if (managementObj != null)
            {
                foreach (ManagementObject managementObject in managementObj)
                {
                    VideoCardProperties.Add(new VideoCardComponent());
                    int lastIndex = VideoCardProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        VideoCardProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(VideoCardProperties[lastIndex], propData.Value);
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
