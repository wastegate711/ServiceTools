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
        public double RequestInterval { get; } = 500;

        /// <summary>
        /// Таймаут отправки сообщений.(эта величена должна быть меньше RequestInterval иначе таймаут
        /// будет срабатывать не вовремя.)
        /// </summary>
        public double RequestTimeOut { get; } = 490;

        public string PortName { get; } = "com3";
    }
}
