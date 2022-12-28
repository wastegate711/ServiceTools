using ServiceTools.Core.Extensions;
using ServiceTools.Core.Enums;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.ControlBlock.Interfaces;

namespace ServiceTools.Services.ControlBlock.Services
{
    public class Requests : IRequests
    {
        private readonly GlobalSettings _globalSettings;
        private readonly IMessageQueue _messageQueue;
        private readonly IMessageTools _messageTools;

        public Requests(
            GlobalSettings globalSettings,
            IMessageQueue messageQueue,
            IMessageTools messageTools)
        {
            _globalSettings = globalSettings;
            _messageQueue = messageQueue;
            _messageTools = messageTools;
        }

        /// <summary>
        /// Управляет состоянием клапана холодная вода
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveCoolWater(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
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
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
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
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
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
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveOsmos));
        }

        /// <summary>
        /// Управляет состоянием клапана Пена
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveFoam(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveFoam));
        }

        /// <summary>
        /// Управляет состоянием клапана Сброс давления.
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveDrop(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveDrop));
        }

        /// <summary>
        /// Управляет состоянием клапана Средство от насекомых
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetValveInsect(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveInsect));
        }

        /// <summary>
        /// Управляет состоянием дозатора Пена
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetDispenserFoam(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserFoam));
        }

        /// <summary>
        /// Управляет состоянием дозатора Воск
        /// </summary>
        /// <param name="state">Состояние Off/On</param>
        public void SetDispenserVosk(State state)
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { (byte)state },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserVosk));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Холодная вода
        /// </summary>
        public void GetValveCoolWater()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveCoolWater));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Горячая вода
        /// </summary>
        public void GetValveHotWater()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveHotWater));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Осмос
        /// </summary>
        public void GetValveOsmos()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveOsmos));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Воздух
        /// </summary>
        public void GetValveAir()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveAir));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Средство от насекомых
        /// </summary>
        public void GetValveInsect()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveInsect));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Пена
        /// </summary>
        public void GetValveFoam()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveFoam));
        }

        /// <summary>
        /// Отправляет команду запроса состояния клапана Сброс давления
        /// </summary>
        public void GetValveDrop()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetValveDrop));
        }

        /// <summary>
        /// Отправляет команду запроса состояния дозатора Пена
        /// </summary>
        public void GetDispenserFoam()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetDispenserFoam));
        }

        /// <summary>
        /// Отправляет команду запроса состояния дозатора Воск
        /// </summary>
        public void GetDispenserVosk()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetDispenserVosk));
        }

        /// <summary>
        /// Отправляет команду запроса состояния датчика потока
        /// </summary>
        public void GetSensorStream()
        {
            _messageQueue.AddMessageToQueue(_messageTools.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetSensorStream));
        }
    }
}
