using System;

namespace ScriptDotNet
{
    public class IncomingGumpEventArgs : EventArgs
    {
        public IncomingGumpEventArgs(int serial, int gumpId, int x, int y)
        {
            Serial = serial;
            GumpId = gumpId;
            X = x;
            Y = y;
        }
        public int Serial { get; private set; }
        public int GumpId { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
    }


}
