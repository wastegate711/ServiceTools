namespace ServiceTools.Core.Enums;

public enum Command : byte
{
    GetStatus = 0x01,
    GetSerialNumber = 0x02,
    SetValveCoolWater = 0x03,
    SetValveHotWater = 0x04,
    SetValveOsmos = 0x05,
    SetValveFoam = 0x06,
    SetValveAir = 0x07,
    SetValveInsect = 0x08,
    SetValveDrop = 0x09,
    SetDispenserFoam = 0x0A,
    SetDispenserVosk = 0x0B,
    GetSensorStream = 0x0C,
    GetValveCoolWater = 0x0D,
    GetValveHotWater = 0x0E,
    GetValveOsmos = 0x0F,
    GetValveFoam = 0x10,
    GetValveAir = 0x11,
    GetValveInsect = 0x12,
    GetValveDrop = 0x13,
    GetDispenserFoam = 0x14,
    GetDispenserVosk = 0x15
}