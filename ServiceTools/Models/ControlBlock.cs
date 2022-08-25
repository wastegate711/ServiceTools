using System.Windows.Media;

namespace ServiceTools.Models
{
    public class ControlBlock
    {
        /// <summary>
        /// Версия программы устройства.
        /// </summary>
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Серийный номер устройства.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Дата/Время установленые в блоке управления.
        /// </summary>
        public string DateTimeDevice { get; set; }

        /// <summary>
        /// Цвет кнопки Осмос.
        /// </summary>
        public SolidColorBrush BacklightOsmosBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Холодная вода.
        /// </summary>
        public SolidColorBrush BacklightCoolWaterBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Горячая вода.
        /// </summary>
        public SolidColorBrush BacklightHotWaterBrush { get; set; }

        /// <summary>
        /// Цвет кнопки клапан Пена.
        /// </summary>
        public SolidColorBrush BacklightFoamBrush { get; set; }

        /// <summary>
        /// Цвет кнопки клапан Воздух.
        /// </summary>
        public SolidColorBrush BacklightAirBrush { get; set; }
        /// <summary>
        /// Цвет кнопки клана Средство от насекомых.
        /// </summary>
        public SolidColorBrush BacklightInsectBrush { get; set; }

        /// <summary>
        /// Цвет кнопки дозатора Пена.
        /// </summary>
        public SolidColorBrush BacklightDispenserFoamBrush { get; set; }

        /// <summary>
        /// Цвет кнопки дозатора Воск.
        /// </summary>
        public SolidColorBrush BacklightDispenserVoskBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Клапан сброса.
        /// </summary>
        public SolidColorBrush BacklightDropBrush { get; set; }
    }
}
