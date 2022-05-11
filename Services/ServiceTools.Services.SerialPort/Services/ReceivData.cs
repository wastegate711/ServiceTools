using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Services.SerialPort.Services
{
    public class ReceivData : IReceivData
    {
        private bool accessFlag = false;
        ///<inheritdoc/>
        public void ReadData(byte[] buf)
        {
            if (buf.CompareCrc16())
            {
                accessFlag = true;
            }
        }

    }
}
