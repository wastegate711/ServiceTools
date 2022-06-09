using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Core.Extensions;
using ServiceTools.Services.SerialPort.Tools;

namespace ServiceTools.Services.SerialPort.Services
{
    public class MessageQueue : IMessageQueue
    {
        private readonly GlobalSettings _globalSettings;

        /*
         * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [длина сообщения 1 байт]
         * [4] = [данные 0-251 байт]
         * [5] = [CRC16-2 байта]
         */
        private Queue<byte[]> _queue = new Queue<byte[]>();
        private byte[] controlBlockData = new byte[6];
        private byte[] pultData = new byte[6];
        private int _messageCount = 0;
        /// <summary>
        /// Счетчик сообщений, по этому счетчику определяется
        /// какому устройству будет отправлен базовый запрос.
        /// </summary>
        private int MessageCount
        {
            get => _messageCount;
            set
            {//если произошло переполнение счетчика обнуляем его.
                if (_messageCount == int.MaxValue)
                    _messageCount = 0;

                _messageCount = value;
            }
        }

        /// <summary>
        /// Возвращает количество сообщений в очереди.
        /// </summary>
        public int QueueCount => _queue.Count;

        public MessageQueue(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
            //Базовый запрос состояния блока управления.
            controlBlockData[0] = _globalSettings.CompAddress;
            controlBlockData[1] = _globalSettings.ControlBlockAddress;
            controlBlockData[2] = 0x01;
            controlBlockData[3] = 0x08;
            controlBlockData[4] = 0x00;
            controlBlockData[5] = 0x00;
            //Базовый запрос состояния пульта.
            pultData[0] = _globalSettings.CompAddress;
            pultData[1] = _globalSettings.PultAddress;
            pultData[2] = 0x01;
            pultData[3] = 0x08;
            pultData[4] = 0x00;
            pultData[5] = 0x00;
        }

        /// <summary>
        /// Добавляет данные для отправки в конец очереди.
        /// </summary>
        /// <param name="data">Массив с данными которые нужно добавить в очередь.</param>
        public void AddMessageToQueue(byte[] data)
        {
            _queue.Enqueue(data);
        }

        byte[] ConstructorRequest(byte[] data)
        {
            return null; //TODO необходимо доделать.
        }
        /// <inheritdoc/>
        public byte[] ConstructorCommand(byte[] data, byte address, byte cmd)
        {
            byte[] temp = new byte[data.Length + 4]; //+4 это байты которые необходимо добавить к общей длине посылки,
            // это адрес ведущего, адрес ведомого, команда и длина сообщения.
            temp[0] = _globalSettings.CompAddress;
            temp[1] = address;
            temp[2] = cmd;
            temp[3] = (byte)((byte)temp.Length + 2);
            Array.Copy(data, 0, temp, 4, data.Length);
            //byte[] crc = temp.GetCrc16().ToArrayCrc();
            //temp[^2] = crc[0];
            //temp[^1] = crc[1];

            return temp;
        }
        /// <summary>
        /// Возвращает из очереди сообщений первое сообщение и удаляет его из очереди,
        /// если очередь пуста вернет базовое сообщение
        /// для Блока управления или Пульта.
        /// </summary>
        /// <returns>Сообщение для отправки его устройству.</returns>
        public byte[] GetMessageFromQueue()
        {
            if (_queue.TryDequeue(out byte[]? data))
            {
                return data ?? throw new Exception("Из очереди сообщений \"MessageQueue\" не удалось извлеч сообщение.");
            }
            else
            {
                MessageCount++;

                //return MessageCount % 2 == 0 ? controlBlockData : pultData;
                return MessageCount % 2 == 1 ? controlBlockData : pultData;
            }
        }
    }
}
