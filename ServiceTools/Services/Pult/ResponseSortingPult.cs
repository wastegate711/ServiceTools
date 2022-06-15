using ServiceTools.Interfaces.Pult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTools.Services.Pult
{
    public class ResponseSortingPult : IResponseSortingPult
    {

        public ResponseSortingPult()
        {
            
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
