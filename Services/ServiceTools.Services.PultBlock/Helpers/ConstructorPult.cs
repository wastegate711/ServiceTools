using ServiceTools.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTools.Services.PultBlock.Interfaces.Helpers;

namespace ServiceTools.Services.PultBlock.Helpers
{
    public class ConstructorPult : IConstructorPult
    {
        private readonly GlobalSettings _globalSettings;

        public ConstructorPult(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }
        /// <inheritdoc/>
        public byte[] ConstructorCommand(byte[] data, byte address, byte cmd)
        {
            byte[] temp = new byte[data.Length + 4]; //+4 это байты которые необходимо добавить к общей длине посылки,
            // это адрес ведущего, адрес ведомого, команда и длина сообщения.
            temp[0] = _globalSettings.CompAddress;
            temp[1] = address;
            temp[2] = cmd;
            temp[3] = (byte)((byte)temp.Length + 2); // +2 добавляется для учета CRC16
            Array.Copy(data, 0, temp, 4, data.Length);
            //CRC16 считается при отправке.
            //byte[] crc = temp.GetCrc16().ToArrayCrc();
            //temp[^2] = crc[0];
            //temp[^1] = crc[1];

            return temp;
        }
    }
}
