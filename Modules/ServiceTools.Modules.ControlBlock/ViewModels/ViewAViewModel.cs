using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Modules.ControlBlock.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel()
        {
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
    }
}
