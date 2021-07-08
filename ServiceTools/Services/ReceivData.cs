using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace ServiceTools.Services
{
    class ReceivData
    {
        private SerialPort serialPort;
        public ReceivData(string portName)
        {
            serialPort = new SerialPort(portName);
        }

        public async Task<byte[]> RecievSerialPort(CancellationTokenSource cancellationTokenSource)
        {
            var result;
            return result;
        }
    }
}
