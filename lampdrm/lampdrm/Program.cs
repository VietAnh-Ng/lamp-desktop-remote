using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lampdrm
{
    class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr h, string m, string c, int type);

        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length != 1 || string.IsNullOrEmpty(args[0]) || (!args[0].Equals("on") && !args[0].Equals("off")))
                {
                    MessageBox(IntPtr.Zero, $"Command invalid", "Error", 0);
                    return;
                }

                RegistryKey regKey = Registry.LocalMachine.OpenSubKey("\\SOFTWARE");
                string com = (string)regKey.GetValue("lampdrm");
                if(string.IsNullOrEmpty(com))
                {
                    MessageBox(IntPtr.Zero, "Please set Comport in register.reg and run again", "Error", 0);
                    return;
                }
                SerialPort serialPort = new SerialPort(com, 9600);
                serialPort.Open();

                switch(args[0])
                {
                    case "on":
                        serialPort.Write(new byte[] { 0xF0 }, 0, 1);
                        break;
                    case "off":
                        serialPort.Write(new byte[] { 0xAA }, 0, 1);
                        break;
                }
                serialPort.Close();
            }
            catch(Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.ToString(), "Error", 0);
            }
        }
    }
}
