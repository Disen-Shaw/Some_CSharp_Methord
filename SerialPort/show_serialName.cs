
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                // Create a WMI query for the device name
                string query = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + portName + "%'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Get the device name from the query result
                foreach (ManagementObject obj in searcher.Get())
                {
                    string deviceName = obj["Name"] as string;
                    Console.WriteLine(deviceName);
                }
            }
        }
    }
}
