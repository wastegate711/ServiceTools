namespace ServiceTools.Core.Enums;

public enum Command : byte
{
    /// <summary>
    /// Запрос текущего состояния
    /// </summary>
    GetStatus = 0x01,
    /// <summary>
    /// Запрос серийного номера устройства
    /// </summary>
    GetSerialNumber = 0x02,
    /// <summary>
    /// Установка состояния клапана Холодная вода
    /// </summary>
    SetValveCoolWater = 0x03,
    /// <summary>
    /// Установка состояния клапана Горячая вода
    /// </summary>
    SetValveHotWater = 0x04,
    /// <summary>
    /// Установка состояния клапана Осмос
    /// </summary>
    SetValveOsmos = 0x05,
    /// <summary>
    /// Установка состояния клапана Пена
    /// </summary>
    SetValveFoam = 0x06,
    /// <summary>
    /// Установка состояния клапана Воздух
    /// </summary>
    SetValveAir = 0x07,
    /// <summary>
    /// Установка состояния клапана Средство от насекомых
    /// </summary>
    SetValveInsect = 0x08,
    /// <summary>
    /// Установка состояния клапана Сброс
    /// </summary>
    SetValveDrop = 0x09,
    /// <summary>
    /// Установка состояния дозатора Пена
    /// </summary>
    SetDispenserFoam = 0x0A,
    /// <summary>
    /// Установка состояния дозатора Воск
    /// </summary>
    SetDispenserVosk = 0x0B,
    /// <summary>
    /// Запрос текущего состояния датчика потока
    /// </summary>
    GetSensorStream = 0x0C,
    /// <summary>
    /// Запрос текущего состояния клапана Холодная вода
    /// </summary>
    GetValveCoolWater = 0x0D,
    /// <summary>
    /// Запрос текущего состояния клапана Горячая вода
    /// </summary>
    GetValveHotWater = 0x0E,
    /// <summary>
    /// Запрос текущего состояния клапана Осмос
    /// </summary>
    GetValveOsmos = 0x0F,
    /// <summary>
    /// Запрос текущего состояния клапана Пена
    /// </summary>
    GetValveFoam = 0x10,
    /// <summary>
    /// Запрос текущего состояния клапана Воздух
    /// </summary>
    GetValveAir = 0x11,
    /// <summary>
    /// Запрос текущего состояния клапана Средство от насекомых
    /// </summary>
    GetValveInsect = 0x12,
    /// <summary>
    /// Запрос текущего состояния клапана Сброс
    /// </summary>
    GetValveDrop = 0x13,
    /// <summary>
    /// Запрос текущего состояния дозатора Пена
    /// </summary>
    GetDispenserFoam = 0x14,
    /// <summary>
    /// Запрос текущего состояния дозатора Воск
    /// </summary>
    GetDispenserVosk = 0x15,
    /// <summary>
    /// Установка состояния подсветки кнопки Средство от насекомых
    /// </summary>
    SetBacklightButtonInsect = 0x16,
    /// <summary>
    /// Установка состояния подсветки кнопки Пена
    /// </summary>
    SetBacklightButtonFoam = 0x17,
    /// <summary>
    /// Установка состояния подсветки кнопки Пена + вода
    /// </summary>
    SetBacklightButtonFoamWater = 0x18,
    /// <summary>
    /// Установка состояния подсветки кнопки Горячая вода
    /// </summary>
    SetBacklightButtonHotWater = 0x19,
    /// <summary>
    /// Установка состояния подсветки кнопки Холодная вода
    /// </summary>
    SetBacklightButtonCoolWater = 0x1A,
    /// <summary>
    /// Установка состояния подсветки кнопки Воск
    /// </summary>
    SetBacklightButtonVosk = 0x1B,
    /// <summary>
    /// Установка состояния подсветки кнопки Осмос
    /// </summary>
    SetBacklightButtonOsmos = 0x1C,
    /// <summary>
    /// Установка состояния подсветки кнопки Стоп
    /// </summary>
    SetBacklightButtonStop = 0x1D,
    /// <summary>
    /// Нажата кнопка Средство от насекомых
    /// </summary>
    PushButtonInsect = 0x1E,
    /// <summary>
    /// Нажата кнопка Инкассация
    /// </summary>
    PushButtonCollection = 0x1F,
    /// <summary>
    /// Установка значения на дисплее
    /// </summary>
    SetDisplayNumber = 0x20,
    /// <summary>
    /// Принят жетон по первому каналу
    /// </summary>
    PushJettonChanel1 = 0x21,
    /// <summary>
    /// Принят жетон по 2 каналу
    /// </summary>
    PushJettonChanel2 = 0x22,
    /// <summary>
    /// Принят жетон по 3 каналу
    /// </summary>
    PushJettonChanel3 = 0x23,
    /// <summary>
    /// Нажата кнопка Пена
    /// </summary>
    PushButtonFoam = 0x24,
    /// <summary>
    /// Нажата кнопка Пена + вода
    /// </summary>
    PushButtonFoamWater = 0x25,
    /// <summary>
    /// Нажата кнопка Горячая вода
    /// </summary>
    PushButtonHotWater = 0x26,
    /// <summary>
    /// Нажата кнопка Холодная вода
    /// </summary>
    PushButtonCoolWater = 0x27,
    /// <summary>
    /// Нажата кнопка Воск
    /// </summary>
    PushButtonVosk = 0x28,
    /// <summary>
    /// Нажата кнопка Осмос
    /// </summary>
    PushButtonOsmos = 0x29,
    /// <summary>
    /// Нажата кнопка Стоп
    /// </summary>
    PushButtonStop = 0x2A
}