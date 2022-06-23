using ServiceTools.Core.Extensions;
using ServiceTools.Services.PultBlock.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTools.Core.Enums;
using ServiceTools.Services.PultBlock.Helpers;
using ServiceTools.Services.PultBlock.Interfaces.Helpers;

namespace ServiceTools.Services.PultBlock.Services
{
    public class RequestsPult : IRequestsPult
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IConstructorPult _constructorPult;

        public RequestsPult(GlobalSettings globalSettings, IConstructorPult constructorPult)
        {
            _globalSettings = globalSettings;
            _constructorPult = constructorPult;
        }

        /// <inheritdoc/>
        public byte[] SetBacklightButtonInsect(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonInsect);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonFoam(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonFoam);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonFoamWater(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonFoamWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonHotWater(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonHotWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonCoolWater(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonCoolWater);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonVosk(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonVosk);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonOsmos(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonOsmos);
        }

        /// <inheritdoc />
        public byte[] SetBacklightButtonStop(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.SetBacklightButtonStop);
        }

        /// <inheritdoc/>
        public byte[] GetSerialNumberDevice()
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.PultAddress,
                (byte)Command.GetSerialNumber);
        }

        /// <inheritdoc/>
        public byte[] GetSoftwareVersion()
        {
            return _constructorPult.ConstructorCommand(
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

            return _constructorPult.ConstructorCommand(
                data,
                _globalSettings.PultAddress,
                (byte)Command.SetDisplayNumber);
        }

        /// <inheritdoc/>
        public byte[] SetLockCoinAcceptor(State state)
        {
            return _constructorPult.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.PultAddress,
                (byte)Command.LockCoinAcceptor);
        }
    }
}
