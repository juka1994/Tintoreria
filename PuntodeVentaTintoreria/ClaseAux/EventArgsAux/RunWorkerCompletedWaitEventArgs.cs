using System;

namespace PuntodeVentaTintoreria.ClaseAux.EventArgsAux
{
    public class RunWorkerCompletedWaitEventArgs : EventArgs
    {
        public RunWorkerCompletedWaitEventArgs()
        {

        }

        public Exception Error { get; set; }
        public object Result { get; set; }
        public bool Cancelled { get; set; }
    }
}
