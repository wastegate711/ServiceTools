namespace ServiceTools.Services.SerialPort.Interfaces;

public interface IReceivData
{
    /// <summary>
    /// Принимает входящие данные из порта
    /// </summary>
    /// <param name="buf">Массив с данными для обработки.</param>
    public void ReadData(byte[] buf);
}