using System.ComponentModel;
using System.Reflection;
using HardwareServices;

namespace HardwareGUI
{
    // Utilities for adding component to the GUI
    class Utilities
    {
        /// <summary>
        /// A helper class to add a single component to a root node
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="singleComponent">Component to pull properties from</param>
        public static void AddSingleComponent(MenuItem root, SingleComponent singleComponent)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Title = singleComponent.ToString();

            //for each property add it as a menu item
            foreach (PropertyInfo propertyInfo in singleComponent.GetType().GetProperties())
            {
                string displayName = GetDisplayName(propertyInfo);
                if (string.IsNullOrEmpty(displayName) == false)
                {
                    menuItem.Items.Add(new MenuItem() { Title = $"{displayName}: {propertyInfo.GetValue(singleComponent, null)}" });
                }
            }

            root.Items.Add(menuItem);
        }

        /// <summary>
        /// Get the DisplayName attribute from the passed property.
        /// </summary>
        /// <param name="propertyInfo">Property Information</param>
        /// <returns></returns>
        private static string GetDisplayName(PropertyInfo propertyInfo)
        {
            object[] displayNameList = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (displayNameList.Length > 0 && displayNameList[0] is DisplayNameAttribute displayName)
            {
                return displayName.DisplayName;
            }
            return null;
        }

        /// <summary>
        /// A helper class to add multiple components to a root node.
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="multipleComponents">A component with a list of single component inside</param>
        public static void AddMultipleComponents(MenuItem root, MultipleComponents multipleComponents)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Title = multipleComponents.ToString();

            foreach (object obj in multipleComponents.Components)
            {
                if (obj is SingleComponent single)
                {
                    AddSingleComponent(menuItem, single);
                }
            }

            root.Items.Add(menuItem);
        }
    }
}
