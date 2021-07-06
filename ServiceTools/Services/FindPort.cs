using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Services
{
    internal class FindPort
    {
        SerialPort serialPort;

        public FindPort()
        {
            serialPort = new SerialPort();
        }

        public string[] GetSerialPort()
        {
            return SerialPort.GetPortNames();
        }
    }
}
