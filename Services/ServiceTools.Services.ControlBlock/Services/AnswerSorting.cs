using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTools.Services.ControlBlock.Interfaces;

namespace ServiceTools.Services.ControlBlock.Services
{
    public class AnswerSorting : IAnswerSorting
    {
        /// <inheritdoc/>
        public void IncomingResponses(byte[] data)
        {
            switch (data[3])
            {
                case 0x00:
                    break;
                case 0x01:
                    break;
                case 0x03:
                    break;
                default:
                    break;
            }
        }
    }
}
