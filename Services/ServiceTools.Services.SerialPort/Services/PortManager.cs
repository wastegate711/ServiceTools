using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SerialPortService.Abstractions;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Tools;
using Timer = System.Timers.Timer;

namespace ServiceTools.Services.SerialPort.Services
{
    public class PortManager : IPortManager
    {
        private readonly ISerialPortService _serialPortService = null!;
        private readonly IReceivData _receivData;
        private readonly IMessageQueue _messageQueue;

        private Timer _timeOutTimer = null!;
        private Timer _sendDataTimer = null!;
        byte[] sendData = null!;
        public double TimeOutInterval { get; set; } = 3000;//TODO заменить на глобальные настройки.
        public int SendDataInterval { get; set; } = 3000;//TODO заменить на глобальные настройки.

        public PortManager(IMessageQueue messageQueue,
            ISerialPortService serialPortService,
            IReceivData receivData)
        {
            _serialPortService = serialPortService;
            _receivData = receivData;
            _messageQueue = messageQueue;
            Initialization(); //TODO удалить
        }
        
        /// <inheritdoc/>
        public void Initialization()
        {
            //таймаут таймер настройка.
            _timeOutTimer = new Timer();
            _timeOutTimer.Interval = TimeOutInterval;
            _timeOutTimer.Elapsed += TimeOutTimer_Elapsed;
            _timeOutTimer.AutoReset = true;
            //_timeOutTimer.Enabled = true;
            //таймер отправки данных настройка.
            _sendDataTimer = new Timer();
            _sendDataTimer.Interval = SendDataInterval;
            _sendDataTimer.Elapsed += SendDataTimer_Elapsed;
            _sendDataTimer.AutoReset = true;
            //_sendDataTimer.Enabled = true;

            //настройка СОМ порта.
            //_serialPortService = new Serial_Port("com3", 115200);

            _serialPortService.BaudRate = 115200;
            _serialPortService.DataBit = 8;
            _serialPortService.PortName = "com3";
            _serialPortService.DataReceived += SerialPortService_DataReceived;

            if (!_serialPortService.Open())
            {
                throw new Exception($"Порт не открылся.");
            }

            _sendDataTimer.Start();
        }

        /// <inheritdoc/>
        public void WriteData(byte[] data)
        {
            try
            {
                //создаем массив, вычисляем для него CRC16 и отправляем в порт.
                byte[] dataCrc = new byte[data.Length + 2];
                var crc = data.GetCrc16().ToArrayCrc();
                dataCrc[^2] = crc[0];
                dataCrc[^1] = crc[1];
                _serialPortService.Write(dataCrc);
                // включается таймер отсчета таймаута, на случай если ответ не придет.
                _timeOutTimer.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ~PortManager()
        {
            Dispose();
        }

        public void Dispose()
        {
            _sendDataTimer.Stop();
            _sendDataTimer.Dispose();
            _timeOutTimer.Stop();
            _timeOutTimer.Dispose();
            _serialPortService.Close();
        }

        /// <summary>
        /// Событие срабатывает при поступлении данных в порт.
        /// </summary>
        /// <param name="obj"></param>
        private void SerialPortService_DataReceived(byte[] obj)
        {
            _receivData.ReadData(obj);
            _timeOutTimer.Stop();
        }
        // ведет постоянную отправку сообщений в сеть по таймеру.
        private void SendDataTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            // извлекает сообщение из очереди сообщений и отправляет его устройству
            WriteData(_messageQueue.GetMessageFromQueue());
        }

        private void TimeOutTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {

        }

        /// <summary>
        /// Сбрасывает период таймера на начальное значение и активирует его.
        /// </summary>
        /// <param name="timer">Ссылка на экземпляр таймера.</param>
        private void ResetTimerPeriod(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
