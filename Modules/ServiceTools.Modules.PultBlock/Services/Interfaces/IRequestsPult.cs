using ServiceTools.Core.Enums;

namespace ServiceTools.Modules.PultBlock.Services.Interfaces;

public interface IRequestsPult
{
        /// <summary>
    /// Управляет состояние подсветки кнопки Средство от насекомых.
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonInsect(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Пена
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonFoam(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Пена + вода
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonFoamWater(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Горячая вода
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonHotWater(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Холодная вода
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonCoolWater(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Воск
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonVosk(State state);

    /// <summary>
    /// Управляет состояние подсветки кнопки Осмос
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetBacklightButtonOsmos(State state);

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

    /// <summary>
    /// Отправляет число для отображения его на дисплее.
    /// </summary>
    /// <param name="number">Число для отображения.</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetDisplayData(ushort number);

    /// <summary>
    /// Управление блокировкой монетоприемника.
    /// </summary>
    /// <param name="state">Состояние On-Включено/Off-выключено</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetLockCoinAcceptor(State state);

    /// <summary>
    /// Команда начислить средства по 1 каналу монетоприемника
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetCoinAcceptorChanel1();

    /// <summary>
    /// Команда начислить средства по 2 каналу монетоприемника
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetCoinAcceptorChanel2();

    /// <summary>
    /// Команда начислить средства по 3 каналу монетоприемника
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] SetCoinAcceptorChanel3();
}