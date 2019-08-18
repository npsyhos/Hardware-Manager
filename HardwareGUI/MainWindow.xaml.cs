using System.Collections.ObjectModel;
using System.Windows;
using HardwareServices;

namespace HardwareGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuItem root = new MenuItem();
            // Create processor first to get the name of the machine
            Processor myProcessor = new Processor();
            root.Title = myProcessor.SystemName;

            // Add each component
            Utilities.AddSingleComponent(root, myProcessor);
            Utilities.AddSingleComponent(root, new OS());
            Utilities.AddSingleComponent(root, new Bios());
            Utilities.AddSingleComponent(root, new Motherboard());
            Utilities.AddMultipleComponents(root, new Display());
            Utilities.AddMultipleComponents(root, new VideoCard());
            Utilities.AddMultipleComponents(root, new RAM());
            Utilities.AddMultipleComponents(root, new StorageDrives());
            Utilities.AddMultipleComponents(root, new NetworkCard());
            Utilities.AddMultipleComponents(root, new USB());

            // Finally append to the root node
            components.Items.Add(root);
        }
    }

    internal class MenuItem
    {
        public MenuItem()
        {
            Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }
}
