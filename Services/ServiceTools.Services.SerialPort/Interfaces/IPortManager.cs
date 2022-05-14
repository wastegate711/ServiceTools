namespace ServiceTools.Services.SerialPort.Interfaces;

public interface IPortManager
{
    /// <summary>
    /// Начальная инициализация таймеров и настроек порта.
    /// </summary>
    public void Initialization();

    /// <summary>
    /// Вычисляет CRC16 и отправляет данные в порт.
    /// </summary>
    /// <param name="data">Массив с данными.</param>
    public void WriteData(byte[] data);

    public void Dispose();
}