using ServiceTools.Core.Extensions;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Services.SerialPort.Tools;

public class MessageTools
{
    private readonly GlobalSettings _globalSettings;
    private readonly IMessageQueue _messageQueue;

    public MessageTools(GlobalSettings globalSettings, IMessageQueue messageQueue)
    {
        _globalSettings = globalSettings;
        _messageQueue = messageQueue;
    }

    /// <inheritdoc/>
    public byte[] ConstructorCommand(byte[] data, byte address, byte cmd)
    {
        byte[] temp = new byte[data.Length + 5]; //+4 это байты которые необходимо добавить к общей длине посылки,
        // это адрес ведущего, адрес ведомого, команда, длина сообщения, номер посылки.
        temp[0] = _globalSettings.CompAddress;
        temp[1] = address;
        temp[2] = cmd;
        temp[3] = _messageQueue.MessageCount;
        temp[4] = (byte)((byte)temp.Length + 2);
        Array.Copy(data, 0, temp, 5, data.Length);

        return temp;
    }

    /// <inheritdoc />
    public byte[] ExtractData(byte[] data)
    {
        byte[] tmp = new byte[data.Length - 6]; // -6 это отсекаем не нужные байты (адресы, команды, CRC16)

        for (int i = 4, n=0; i < data.Length-2; i++, n++)
        {
            tmp[n] = data[i];
        }

        return tmp;
    }
}