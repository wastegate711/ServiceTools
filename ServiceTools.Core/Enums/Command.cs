namespace ServiceTools.Core.Enums;

public enum Command : byte
{
    SetValveCoolWater = 0x03,
    SetValveHotWater = 0x04,
    SetValveOsmos = 0x05,
    SetValveFoam = 0x06,
    SetValveAir = 0x07,
    SetValveInsect = 0x08,
    SetValveDrop = 0x09,
    SetDispenserFoam = 0x0A,
    SetDispenserVosk = 0x0B
}