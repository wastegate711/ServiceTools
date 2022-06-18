using ServiceTools.Core.Enums;

namespace ServiceTools.Services.PultBlock.Interfaces.Services;

public interface IRequestsPult
{
    /// <summary>
    /// Управляет состояние подсветки кнопки Средство от насекомых.
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonInsect(State state);

    /// <summary>
    /// Запрашивает серийный номер устройства.
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] GetSerialNumberDevice();

    /// <summary>
    /// Запрашивает версию программы устройства.
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] GetSoftwareVersion();

    /// <summary>
    /// Управляет состояние подсветки кнопки Стоп
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonStop(State state);
}