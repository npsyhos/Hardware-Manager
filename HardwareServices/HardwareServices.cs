using System;

namespace HardwareServices
{
    class HWManagerServices
    {
        // TODO: Delete when converting to DLL
        /// <summary>
        /// Use for debugging
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Component[] components = { new Motherboard(), new Processor(), new Bios(), new OS(),
                                       new NetworkCard(), new USB(), new RAM(), new StorageDrives(),
                                       new VideoCard(), new Display() };
            foreach (Component component in components)
            {
                Console.WriteLine(component.ToString());
            }
        }
    }
}
