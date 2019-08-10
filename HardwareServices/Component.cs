using System;
using System.Collections.Generic;
using System.Management;

namespace HardwareServices
{
    abstract class Component
    {
        internal abstract string Key { get; set; }

        internal abstract string[] PropertyNames { get; set; }

        internal abstract string Query { get; set; }

        public abstract override string ToString();

        internal abstract void SetPropertyData();

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
        /// Constructs a query based on the Key and ColumnNames
        /// </summary>
        /// <returns></returns>
        internal virtual string ConstructQuery()
        {
            // Construct a query for WMI
            string query = "SELECT ";
            for (int i = 0; i < PropertyNames.Length; i++)
            {
                query += PropertyNames[i];
                if (PropertyNames.Length - i > 1)
                {
                    query += ", ";
                }
            }
            query += $" FROM {Key}";
            return query;
        }
    }

    /// <summary>
    /// Abstract class to be used with components that have
    /// only one obtainable component. e.g.: BIOS, OS, Processor
    /// </summary>
    abstract class SingleComponent : Component
    {
        /// <summary>
        /// Get the property data for the Key from System.Management
        /// </summary>
        /// <returns></returns>
        internal override void SetPropertyData()
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
    }

    /// <summary>
    /// Abstract class to be used with components that have
    /// multiple obtainable components. e.g.: Monitors, NetworkCards
    /// </summary>
    abstract class MultipleComponents : Component
    {
        internal MultipleComponents(object data)
        {
            DataType = data.GetType();
        }

        /// <summary>
        /// Use for creating an instance of each child classes unique subclass
        /// </summary>
        internal Type DataType { get; set; }

        /// <summary>
        /// Stores a list of type Datatype objects containing the properties of a component.
        /// </summary>
        public abstract List<object> DataProperties { get; set; }

        /// <summary>
        /// Get the property data for the Key from System.Management
        /// </summary>
        /// <returns></returns>
        internal override void SetPropertyData()
        {
            // Get the property information on the piece of hardware
            ManagementObjectCollection managementObj = ExecuteQuery();
            // Set the list of property data
            if (managementObj != null)
            {
                foreach (ManagementObject managementObject in managementObj)
                {
                    DataProperties.Add(Activator.CreateInstance(DataType));
                    int lastIndex = DataProperties.Count - 1;
                    foreach (PropertyData propData in managementObject.Properties)
                    {
                        DataProperties[lastIndex].GetType().GetProperty(propData.Name).SetValue(DataProperties[lastIndex], propData.Value);
                    }
                }
            }
        }
    }
}
