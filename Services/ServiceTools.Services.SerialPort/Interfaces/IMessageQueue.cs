namespace ServiceTools.Services.SerialPort.Interfaces;

public interface IMessageQueue
{
    /// <summary>
    /// Добавляет данные для отправки в конец очереди.
    /// </summary>
    /// <param name="data">Массив с данными которые нужно добавить в очередь.</param>
    void AddMessageToQueue(byte[] data);

    /// <summary>
    /// Возвращает из очереди сообщений первое сообщение и удаляет его из очереди,
    /// если очередь пуста вернет базовое сообщение
    /// для Блока управления или Пульта.
    /// </summary>
    /// <returns>Сообщение для отправки его устройству.</returns>
    byte[] GetMessageFromQueue();
}