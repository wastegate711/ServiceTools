using ServiceTools.Core.Enums;

namespace ServiceTools.Modules.ControlBlock.Services.Interfaces;

public interface IRequestsControlBlock
{
    /// <summary>
    /// Управляет состоянием клапана холодная вода
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveCoolWater(State state);

    /// <summary>
    /// Управляет состоянием клапана Горячая вода
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveHotWater(State state);

    /// <summary>
    /// Управляет состоянием клапана Воздух
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveAir(State state);

    /// <summary>
    /// Управляет состоянием клапана Осмос
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveOsmos(State state);

    /// <summary>
    /// Управляет состоянием клапана Пена
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveFoam(State state);

    /// <summary>
    /// Управляет состоянием клапана Сброс давления.
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveDrop(State state);

    /// <summary>
    /// Управляет состоянием клапана Средство от насекомых
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetValveInsect(State state);

    /// <summary>
    /// Управляет состоянием дозатора Пена
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetDispenserFoam(State state);

    /// <summary>
    /// Управляет состоянием дозатора Воск
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] SetDispenserVosk(State state);

    /// <summary>
    /// Команда запроса состояния клапана Холодная вода
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveCoolWater();

    /// <summary>
    /// Команда запроса состояния клапана Горячая вода
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveHotWater();

    /// <summary>
    /// Команда запроса состояния клапана Осмос
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveOsmos();

    /// <summary>
    /// Команда запроса состояния клапана Воздух
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveAir();

    /// <summary>
    /// Команда запроса состояния клапана Средство от насекомых
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveInsect();

    /// <summary>
    /// Команда запроса состояния клапана Пена
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveFoam();

    /// <summary>
    /// Команда запроса состояния клапана Сброс давления
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetValveDrop();

    /// <summary>
    /// Команда запроса состояния дозатора Пена
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetDispenserFoam();

    /// <summary>
    /// Команда запроса состояния дозатора Воск
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetDispenserVosk();

    /// <summary>
    /// Команда запроса состояния датчика потока
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    public byte[] GetSensorStream();

    /// <summary>
    /// Команда запроса серийного номера устройства
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] GetSerialNumber();

    /// <summary>
    /// Команда запроса версии программы в блоке управления
    /// </summary>
    /// <returns>Вернет массив готовый к отправке устройству.</returns>
    byte[] GetSoftwareVersion();
}