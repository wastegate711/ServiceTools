using ServiceTools.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTools.Core.Enums;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.ControlBlock.Interfaces;

namespace ServiceTools.Services.ControlBlock.Services
{
    public class Requests : IRequests
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IMessageQueue _messageQueue;

        public Requests(GlobalSettings globalSettings, IMessageQueue messageQueue)
        {
            _globalSettings = globalSettings;
            _messageQueue = messageQueue;
        }

        /// <summary>
        /// Управляет состоянием клапана холодная вода
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveCoolWater(State state)
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveCoolWater));
        }

        /// <summary>
        /// Управляет состоянием клапана Горячая вода
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveHotWater(State state)
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveHotWater));
        }

        /// <summary>
        /// Управляет состоянием клапана Воздух
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveAir(State state)
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveAir));
        }

        /// <summary>
        /// Управляет состоянием клапана Осмос
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveOsmos(State state)
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveOsmos));
        }
    }
}
