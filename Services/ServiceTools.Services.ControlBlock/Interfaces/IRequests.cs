using ServiceTools.Core.Enums;

namespace ServiceTools.Services.ControlBlock.Interfaces;

public interface IRequests
{
    /// <summary>
    /// Управляет состоянием клапана холодная вода
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveCoolWater(State state);

    /// <summary>
    /// Управляет состоянием клапана Горячая вода
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveHotWater(State state);

    /// <summary>
    /// Управляет состоянием клапана Воздух
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveAir(State state);

    /// <summary>
    /// Управляет состоянием клапана Осмос
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveOsmos(State state);

    /// <summary>
    /// Управляет состоянием клапана Пена
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveFoam(State state);

    /// <summary>
    /// Управляет состоянием клапана Сброс давления.
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveDrop(State state);

    /// <summary>
    /// Управляет состоянием клапана Средство от насекомых
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetValveInsect(State state);

    /// <summary>
    /// Управляет состоянием дозатора Пена
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetDispenserFoam(State state);

    /// <summary>
    /// Управляет состоянием дозатора Воск
    /// </summary>
    /// <param name="state">Состояние Off/On</param>
    public void SetDispenserVosk(State state);

    /// <summary>
    /// Отправляет команду запроса состояния клапана Холодная вода
    /// </summary>
    public void GetValveCoolWater();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Горячая вода
    /// </summary>
    public void GetValveHotWater();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Осмос
    /// </summary>
    public void GetValveOsmos();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Воздух
    /// </summary>
    public void GetValveAir();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Средство от насекомых
    /// </summary>
    public void GetValveInsect();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Пена
    /// </summary>
    public void GetValveFoam();

    /// <summary>
    /// Отправляет команду запроса состояния клапана Сброс давления
    /// </summary>
    public void GetValveDrop();

    /// <summary>
    /// Отправляет команду запроса состояния дозатора Пена
    /// </summary>
    public void GetDispenserFoam();

    /// <summary>
    /// Отправляет команду запроса состояния дозатора Воск
    /// </summary>
    public void GetDispenserVosk();

    /// <summary>
    /// Отправляет команду запроса состояния датчика потока
    /// </summary>
    public void GetSensorStream();
}