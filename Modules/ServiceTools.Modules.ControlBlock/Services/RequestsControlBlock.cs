using ServiceTools.Core.Extensions;
using ServiceTools.Core.Enums;
using ServiceTools.Modules.ControlBlock.Services.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Modules.ControlBlock.Services
{
    /// <summary>
    /// Содержит готовые к отправке запросы для Блока управления.
    /// </summary>
    public class RequestsControlBlock : IRequestsControlBlock
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IMessageTools _messageTools;

        public RequestsControlBlock(GlobalSettings globalSettings, IMessageTools messageTools)
        {
            _globalSettings = globalSettings;
            _messageTools = messageTools;
        }

        /// <inheritdoc />
        public byte[] SetValveCoolWater(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveCoolWater);
        }

        /// <inheritdoc />
        public byte[] SetValveHotWater(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveHotWater);
        }

        /// <inheritdoc />
        public byte[] SetValveAir(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveAir);
        }

        /// <inheritdoc />
        public byte[] SetValveOsmos(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveOsmos);
        }

        /// <inheritdoc />
        public byte[] SetValveFoam(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveFoam);
        }

        /// <inheritdoc />
        public byte[] SetValveDrop(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveDrop);
        }

        /// <inheritdoc />
        public byte[] SetValveInsect(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveInsect);
        }

        /// <inheritdoc />
        public byte[] SetDispenserFoam(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserFoam);
        }

        /// <inheritdoc />
        public byte[] SetDispenserVosk(State state)
        {
            return _messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserVosk);
        }

        /// <inheritdoc />
        public byte[] GetValveCoolWater()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveCoolWater);
        }

        /// <inheritdoc />
        public byte[] GetValveHotWater()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveHotWater);
        }

        /// <inheritdoc />
        public byte[] GetValveOsmos()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveOsmos);
        }

        /// <inheritdoc />
        public byte[] GetValveAir()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveAir);
        }

        /// <inheritdoc />
        public byte[] GetValveInsect()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveInsect);
        }

        /// <inheritdoc />
        public byte[] GetValveFoam()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveFoam);
        }

        /// <inheritdoc />
        public byte[] GetValveDrop()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveDrop);
        }

        /// <inheritdoc />
        public byte[] GetDispenserFoam()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetDispenserFoam);
        }

        /// <inheritdoc />
        public byte[] GetDispenserVosk()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetDispenserVosk);
        }

        /// <inheritdoc />
        public byte[] GetSensorStream()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetSensorStream);
        }

        /// <inheritdoc />
        public byte[] GetSerialNumber()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetSerialNumber);
        }

        /// <inheritdoc />
        public byte[] GetSoftwareVersion()
        {
            return _messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetSoftwareVersion);
        }
    }
}
