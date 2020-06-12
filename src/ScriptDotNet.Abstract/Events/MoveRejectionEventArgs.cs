using System;

namespace ScriptDotNet
{
    public class MoveRejectionEventArgs : EventArgs
    {
        public MoveRejectionEventArgs(ushort xSource, ushort ySource, byte direction, ushort xDest, ushort yDest)
        {
            XSource = xSource;
            YSource = ySource;
            Direction = direction;
            XDest = xDest;
            YDest = yDest;
        }

        public ushort XSource { get; private set; }
        public ushort YSource { get; private set; }
        public byte Direction { get; private set; }
        public ushort XDest { get; private set; }
        public ushort YDest { get; private set; }
    }


}
