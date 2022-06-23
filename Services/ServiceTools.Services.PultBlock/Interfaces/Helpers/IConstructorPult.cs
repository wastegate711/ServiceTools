namespace ServiceTools.Services.PultBlock.Interfaces.Helpers;

public interface IConstructorPult
{
    /// <summary>
    /// Конструктор запросов, собирает из данных готовую к отправке посылку.
    /// </summary>
    /// <param name="data">Данные</param>
    /// <param name="address">Адрес устройства</param>
    /// <param name="cmd">Команда</param>
    /// <returns></returns>
    byte[] ConstructorCommand(byte[] data, byte address, byte cmd);

    /// <summary>
    /// Извекает данные из входящих сообщений.
    /// </summary>
    /// <param name="data">Входящее сообщение от ведомого.</param>
    /// <returns>Вернет только данные содержащиеся в сообщении.</returns>
    byte[] ExtractData(byte[] data);
}