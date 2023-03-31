namespace ServiceTools.Services.SerialPort.Interfaces;

public interface IPortManager
{
    /// <summary>
    /// Начальная инициализация таймеров и настроек порта.
    /// </summary>
    void Initialization();

    /// <summary>
    /// Вычисляет CRC16 и отправляет данные в порт.
    /// </summary>
    /// <param name="data">Массив с данными.</param>
    void WriteData(byte[] data);
    void Dispose();

    /// <summary>
    /// Срабатывает при получении данных из порта.
    /// </summary>
    event Action<byte[]> ReceivedData;

    /// <summary>
    /// Останавливает передачу сообщений в сеть RS-485
    /// </summary>
    void StopSendData();

    /// <summary>
    /// Запускает передачу сообщений в сеть RS-485
    /// </summary>
    void StartSendData();
}