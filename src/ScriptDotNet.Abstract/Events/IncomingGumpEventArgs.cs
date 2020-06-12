using System;

namespace ScriptDotNet
{
    public class IncomingGumpEventArgs : EventArgs
    {
        public IncomingGumpEventArgs(uint serial, uint gumpId, uint x, uint y)
        {
            Serial = serial;
            GumpId = gumpId;
            X = x;
            Y = y;
        }
        public uint Serial { get; private set; }
        public uint GumpId { get; private set; }
        public uint X { get; private set; }
        public uint Y { get; private set; }
    }


}
