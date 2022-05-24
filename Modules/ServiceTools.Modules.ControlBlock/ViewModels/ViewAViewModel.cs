using Prism.Commands;
using Prism.Mvvm;
using ServiceTools.Services.SerialPort.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ServiceTools.Modules.ControlBlock.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IMessageQueue _messageQueue;

        public ViewAViewModel(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
            DateTimeDevice = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
        //Свойства
        #region Серийный номер

        private string _serialNumber = "123";
        /// <summary>
        /// Содержит UID устройства
        /// </summary>
        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }

        #endregion

        #region Дата и время

        private string _dateTimeDevice;
        /// <summary>
        /// Дата/Время установленые в блоке управления.
        /// </summary>
        public string DateTimeDevice
        {
            get => _dateTimeDevice;
            set => SetProperty(ref _dateTimeDevice, value);
        }

        #endregion

        #region Цвет кнопки Холодная вода

        private SolidColorBrush _coolWaterBrush = Brushes.Red;
        public SolidColorBrush CoolWaterBrush
        {
            get => _coolWaterBrush;
            set => SetProperty(ref _coolWaterBrush, value);
        }

        #endregion
        //Команды

        #region Управление клапаном Холодная вода

        private DelegateCommand _coolWaterCommand;
        public DelegateCommand CoolWaterCommand =>
            _coolWaterCommand ?? (_coolWaterCommand = new DelegateCommand(ExecuteCoolWater));

        void ExecuteCoolWater()
        {
            byte[]
            _messageQueue.AddMessageToQueue();
        }

        #endregion
    }
}
