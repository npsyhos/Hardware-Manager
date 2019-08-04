using System;
using System.Management;

namespace HardwareServices
{
    abstract class Component
    {
        internal abstract string Key { get; set; }

        internal abstract string[] ColumnNames { get; set; }

        internal abstract string Query { get; set; }

        public abstract override string ToString();

        /// <summary>
        /// Execute a query based on the Key
        /// </summary>
        /// <returns></returns>
        internal virtual ManagementObjectCollection ExecuteQuery()
        {
            try
            {
                // Set access to admin, execute the query, and return the results
                return new ManagementObjectSearcher(Query).Get();
            }
            catch (Exception ex)
            {
                // If the query fails, we catch it here
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get the property data for the Key from System.Management
        /// Use with components with only one possible set of property data
        /// </summary>
        /// <returns></returns>
        internal virtual void SetPropertyData()
        {
            // Get the property information on the piece of hardware
            ManagementObjectCollection managementObj = ExecuteQuery();

            // Set the list of property data
            if (managementObj != null)
            {
                foreach (ManagementObject managementObject in managementObj)
                {
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        GetType().GetProperty(propData.Name).SetValue(this, propData.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructs a query based on the Key and ColumnNames
        /// </summary>
        /// <returns></returns>
        internal virtual string ConstructQuery()
        {
            // Construct a query for WMI
            string query = "SELECT ";
            for (int i = 0; i < ColumnNames.Length; i++)
            {
                query += ColumnNames[i];
                if (ColumnNames.Length - i > 1)
                {
                    query += ", ";
                }
            }
            query += $" FROM {Key}";
            return query;
        }
    }
}
