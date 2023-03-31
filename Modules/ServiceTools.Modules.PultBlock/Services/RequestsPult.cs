using ServiceTools.Core.Extensions;
using ServiceTools.Core.Enums;
using ServiceTools.Modules.PultBlock.Services.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Modules.PultBlock.Services
{
    /// <summary>
    /// Содержит команды формирующие данные для отправки запросов.
    /// </summary>
    public class RequestsPult : IRequestsPult
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IMessageTools _messageTools;

        public RequestsPult(GlobalSettings globalSettings, IMessageTools messageTools)
        {
            _globalSettings = globalSettings;
            _messageTools = messageTools;
        }

        /// <inheritdoc/>
        public byte[] SetBacklightButtonInsect(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonInsect);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonFoam(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonFoam);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonFoamWater(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonFoamWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonHotWater(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonHotWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonCoolWater(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonCoolWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonVosk(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonVosk);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonOsmos(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonOsmos);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonStop(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonStop);
        }

        /// <inheritdoc/>
        public byte[] GetSerialNumberDevice()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.GetSerialNumber);
        }

        /// <inheritdoc/>
        public byte[] GetSoftwareVersion()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.GetSoftwareVersion);
        }

        /// <inheritdoc/>
        public byte[] SetDisplayData(ushort number)
        {
            byte[] data = new byte[2];
            data[0] = (byte)(number >> 8);
            data[1] = (byte)number;

            return _messageTools.ConstructorCommand(
                data,
                _globalSettings.PultAddress,
                (byte)Command.SetDisplayNumber);
        }

        /// <inheritdoc/>
        public byte[] SetLockCoinAcceptor(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.LockCoinAcceptor);
        }

        /// <inheritdoc />
        public byte[] SetCoinAcceptorChanel1()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.SetCoinAcceptorChanel1);
        }

        /// <inheritdoc />
        public byte[] SetCoinAcceptorChanel2()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.SetCoinAcceptorChanel2);
        }

        /// <inheritdoc />
        public byte[] SetCoinAcceptorChanel3()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.SetCoinAcceptorChanel3);
        }
    }
}
