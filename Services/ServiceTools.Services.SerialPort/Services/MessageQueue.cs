using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Core.Extensions;

namespace ServiceTools.Services.SerialPort.Services
{
    /// <summary>
    /// Организует очередь сообщений для отправки их ведомым устройствам.
    /// </summary>
    public class MessageQueue : IMessageQueue
    {
        private readonly GlobalSettings _globalSettings;

        /*
         * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [Номер сообщения 1 байт]
         * [4] = [длина сообщения 1 байт]
         * [5] = [данные 0-251 байт]
         * [6-7] = [CRC16-2 байта]
         */
        private Queue<byte[]> _queue = new Queue<byte[]>();
        private byte[] controlBlockData = new byte[7];
        private byte[] pultData = new byte[7];
        private byte _messageCount = 0;
        
        /// <inheritdoc />
        public byte MessageCount
        {
            get => _messageCount;
            private set
            {//если произошло переполнение счетчика обнуляем его.
                if (_messageCount == byte.MaxValue)
                    _messageCount = 0;

                _messageCount = value;
            }
        }

        /// <inheritdoc />
        public int QueueCount => _queue.Count;

        public MessageQueue(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
            // TODO - нужно убрать из конструктора.
            //Базовый запрос состояния блока управления.
            controlBlockData[0] = _globalSettings.CompAddress; // адрес ведущего
            controlBlockData[1] = _globalSettings.ControlBlockAddress; // адрес ведомого
            controlBlockData[2] = 0x01; // команда
            controlBlockData[3] = MessageCount; // номер сообщения.
            controlBlockData[4] = 0x09; // длина сообщения.
            controlBlockData[5] = 0x00; // CRC16
            controlBlockData[6] = 0x00;
            //Базовый запрос состояния пульта.
            pultData[0] = _globalSettings.CompAddress;
            pultData[1] = _globalSettings.PultAddress;
            pultData[2] = 0x01;
            pultData[3] = MessageCount;
            pultData[4] = 0x09;
            pultData[5] = 0x00;
            pultData[6] = 0x00;
        }

        /// <inheritdoc />
        public void AddMessageToQueue(byte[] data)
        {
            _queue.Enqueue(data);
        }

        /// <inheritdoc />
        public byte[] GetMessageFromQueue()
        {
            if (_queue.TryDequeue(out byte[]? data))
            {
                return data ?? throw new Exception("Из очереди сообщений \"MessageQueue\" не удалось извлечь сообщение.");
            }

            MessageCount++;

            //return MessageCount % 2 == 0 ? controlBlockData : pultData;
            return MessageCount % 2 == 1 ? controlBlockData : pultData;
        }
    }
}
