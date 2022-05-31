using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Core.Extensions
{
    public class GlobalSettings
    {
        /// <summary>
        /// Адрес ведущего устройства в сети RS-485
        /// </summary>
        public byte CompAddress { get; } = 0x01;

        /// <summary>
        /// Адрес блока управления.
        /// </summary>
        public byte ControlBlockAddress { get; } = 0x02;

        /// <summary>
        /// Адрес Блока Пульт
        /// </summary>
        public byte PultAddress { get; } = 0x03;

        /// <summary>
        /// Интервал отправки сообщений в сеть RS-485
        /// </summary>
        public double RequestInterval { get; } = 5000;
    }
}
