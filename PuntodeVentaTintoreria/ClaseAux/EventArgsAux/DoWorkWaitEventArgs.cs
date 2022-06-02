using System;

namespace PuntodeVentaTintoreria.ClaseAux.EventArgsAux
{
    
    public class DoWorkWaitEventArgs : EventArgs
    {
        public object Argument { get; set; }
        public object Result { get; set; }
        public bool Cancell { get; set; }
    }
}
