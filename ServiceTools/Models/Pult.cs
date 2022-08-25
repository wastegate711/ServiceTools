using System.Windows.Media;

namespace ServiceTools.Models
{
    public class Pult
    {
        /// <summary>
        /// Серийный номер устройства.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Версия программы устройства.
        /// </summary>
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Текущее время на устройстве.
        /// </summary>
        public string DateTimeDevice { get; set; }

        /// <summary>
        /// 1 канал монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel1 { get; set; }

        /// <summary>
        /// 2 канал монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel2 { get; set; }

        /// <summary>
        /// 3 канал монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel3 { get; set; }

        /// <summary>
        /// Значение отображаемое на дисплее устройства.
        /// </summary>
        public string DisplayValue { get; set; }

        /// <summary>
        /// Цвет кнопки подсветка средство от насекомых.
        /// </summary>
        public SolidColorBrush BacklightInsectBrush { get; set; }

        /// <summary>
        /// Цвет кнопки подсветка Пена.
        /// </summary>
        public SolidColorBrush BacklightFoamBrush { get; set; }

        /// <summary>
        /// Цвет кнопки подсветка Пена + вода.
        /// </summary>
        public SolidColorBrush BacklightFoamWaterBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Горячая вода.
        /// </summary>
        public SolidColorBrush BacklightHotWaterBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Холодная вода.
        /// </summary>
        public SolidColorBrush BacklightCoolWaterBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Воск.
        /// </summary>
        public SolidColorBrush BacklightVoskBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Осмос.
        /// </summary>
        public SolidColorBrush BacklightOsmosBrush { get; set; }

        /// <summary>
        /// Цвет кнопки Стоп.
        /// </summary>
        public SolidColorBrush BacklightStopBrush { get; set; }
    }
}
