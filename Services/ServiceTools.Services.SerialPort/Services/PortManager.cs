using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PortManager : IPortManager, IDisposable
    {
        private readonly ISerialPortService _serialPortService = null!;
        private readonly IMessageQueue _messageQueue;

        private Timer _timeOutTimer = null!;
        private Timer _sendDataTimer = null!;
        byte[] sendData = null!;
        public double TimeOutInterval { get; set; } = 3000;//TODO заменить на глобальные настройки.
        public int SendDataInterval { get; set; } = 3000;//TODO заменить на глобальные настройки.
        /// <inheritdoc/>
        public event Action<byte[]> ReceivedData;

        public PortManager(IMessageQueue messageQueue,
            ISerialPortService serialPortService)
        {
            _serialPortService = serialPortService;
            _messageQueue = messageQueue;

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
                data.CopyTo(dataCrc, 0);
                dataCrc[^2] = crc[0];
                dataCrc[^1] = crc[1];

                if (dataCrc[1] == 0x02)
                    Debug.Write("Отправка данных БУ -->\t");
                else if (dataCrc[1] == 0x03)
                    Debug.Write("Отправка данных БП -->\t");

                foreach (byte item in dataCrc)
                {
                    Debug.Write(item.ToString("X2" + " "));
                }

                Debug.WriteLine("");
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
        /// <param name="data"></param>
        private void SerialPortService_DataReceived(byte[] data)
        {
            //_receivData.ReadData(data);
            RiseReceivedData(data);
            _timeOutTimer.Stop();
        }

        private void RiseReceivedData(byte[] aData)
        {
            ReceivedData?.Invoke(aData);

            foreach (Delegate item in ReceivedData?.GetInvocationList()!)
            {
                Debug.WriteLine(item.Method.Name);
            }
        }
        // ведет постоянную отправку сообщений в сеть по таймеру.
        private void SendDataTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            // извлекает сообщение из очереди сообщений и отправляет его устройству
            // _sendDataTimer.Stop();
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
