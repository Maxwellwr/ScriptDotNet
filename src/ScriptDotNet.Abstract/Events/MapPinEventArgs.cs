using System;

namespace ScriptDotNet
{
    public class MapPinEventArgs : EventArgs
    {
        public MapPinEventArgs(uint id, byte action, byte pinId, ushort x, ushort y)
        {
            ID = id;
            Action = action;
            PinId = pinId;
            X = x;
            Y = y;
        }

        public uint ID { get; private set; }
        public byte Action { get; set; }
        public byte PinId { get; set; }
        public ushort X { get; set; }
        public ushort Y { get; set; }
    }


}
