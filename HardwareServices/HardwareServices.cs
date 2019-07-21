using System;
using System.Linq;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    class HWManagerServices
    {

        //TODO: Update this for all the properties needed
        private static Dictionary<string, string[]> relevantInformation = new Dictionary<string, string[]>
        {
            // First index is always where we are pulling the hardware key from 
            ["bios"] = new []{ "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["mobo"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["memory"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["processor"] = new[] { "Win32_Processor", "Manufacturer", "Name", "Description" },
            ["videocard"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["fans"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["temps"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["drives"] = new[] { "Win32_BIOS", "Manufacturer", "Name", "Description" },
            ["keyboard"] = new[] { "Win32_Keyboard", "Status", "Name" },
        };

        // TODO: Delete when converting to DLL
        /// <summary>
        /// Use for debugging
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine( PrintToConsole("keyboard"));
        }

        /// <summary>
        /// Use for debugging
        /// </summary>
        /// <param name="hardwareName">the unit of hardware we want to print information on</param>
        static bool PrintToConsole(String hardwareName)
        {
            List<Tuple<String, Object>> propertyData = GetPropertyData(hardwareName);
            if (propertyData != null)
            {
                foreach (Tuple<String, Object> tuple in propertyData)
                {
                    Console.WriteLine($"{tuple.Item1}: {tuple.Item2}");
                }
            }

            return propertyData != null;
        }

        /// <summary>
        /// Get the property data for the piece of hw from System.Management
        /// </summary>
        /// <param name="hardwareName"></param>
        /// <returns></returns>
        static List<Tuple<String, Object>> GetPropertyData(String hardwareName)
        {
            // Get the property information on the piece of hardware
            ManagementObject managementObj = ExecuteQuery(hardwareName);

            // Create a list of property data to return to the caller
            List<Tuple<String, Object>> propertyData = null;
            if (managementObj != null)
            {
                propertyData = new List<Tuple<String, Object>>();
                foreach (PropertyData property in managementObj.Properties)
                {
                    propertyData.Add(Tuple.Create(property.Name, property.Value));
                }
            }

            return propertyData;
        }

        /// <summary>
        /// Construct and execute a query based on the name of the hw passed to it
        /// </summary>
        /// <param name="hardwareName">name of the hardware to get info on</param>
        /// <returns></returns>
        static ManagementObject ExecuteQuery(string hardwareName)
        {
            try
            {
                // Construct a query for WMI
                String query = "select ";
                String[] hardwareInfo = relevantInformation[hardwareName];
                for (int i = 1; i < hardwareInfo.Length; i++)
                {
                    query += hardwareInfo[i];
                    if (hardwareInfo.Length - i > 1)
                    {
                        query += ", ";
                    }
                }
                query += $" from {hardwareInfo[0]}";

                // Execute the query, and return the results
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                return searcher.Get().OfType<ManagementObject>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                // If the query fails, we catch it here
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
