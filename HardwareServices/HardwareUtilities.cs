using System;

namespace HardwareServices
{
    class HardwareUtilities
    {
        /// <summary>
        /// Converts the size/capacity to a string contains the correct suffix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rawSize"></param>
        /// <returns></returns>
        public static string ConvertSize<T>(T rawSize)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            ulong size = Convert.ToUInt64(rawSize);
            int i = 0;
            while (size >= 1000)
            {
                size = size / 1024;
                i++;
            }
            return $"{size} {sizes[i]}";
        }

        public static bool ConvertToDatetime(string name)
        {
            if (name == "InstallDate" || name == "LastBootUpTime" || name == "ReleaseDate" || name == "DriverDate")
            {
                return true;
            }
            return false;
        }
    }
}
