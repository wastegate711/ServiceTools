using ServiceTools.Core.Enums;
using ServiceTools.Interfaces.Pult;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.PultBlock.Interfaces.Helpers;
using ServiceTools.Services.PultBlock.Interfaces.Services;
using ServiceTools.Services.SerialPort.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTools.Services.Pult
{
    /*
         * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [длина сообщения 1 байт]
         * [4] = [данные 0-251 байт]
         * [5] = [CRC16-2 байта]
         */
    public class ResponseSortingPult : IResponseSortingPult
    {
        private readonly PultViewViewModel _pultViewViewModel;
        private readonly IConstructorPult _constructorPult;
        private readonly IMessageQueue _messageQueue;
        private readonly IRequestsPult _requestsPult;
        private readonly ViewAViewModel _viewAViewModel;
        Task thredPult;

        public ResponseSortingPult(PultViewViewModel pultViewViewModel,
            IConstructorPult constructorPult,
            IMessageQueue messageQueue,
            IRequestsPult requestsPult,
            ViewAViewModel viewAViewModel)
        {
            _pultViewViewModel = pultViewViewModel;
            _constructorPult = constructorPult;
            _messageQueue = messageQueue;
            _requestsPult = requestsPult;
            _viewAViewModel = viewAViewModel;
        }

        /// <inheritdoc/>
        public void IncomingSorting(byte[] aData)
        {
            switch (aData[2])
            {
                case 0x01:
                    var temp = _requestsPult.GetSerialNumberDevice();
                    _messageQueue.AddMessageToQueue(temp);
                    break;
                case 0x02:
                    var result = string.Concat(_constructorPult.ExtractData(aData));
                    _pultViewViewModel.SerialNumber = result;
                    _viewAViewModel.SerialNumber = result;
                    break;
                default:
                    break;
            }
        }

        public Task StartSorting(byte[] aData, CancellationTokenSource cancellation)
        {
            return Task.Run(() => Work(aData), cancellation.Token);
        }

        private void Work(byte[] aData)
        {
            
        }
    }
}
