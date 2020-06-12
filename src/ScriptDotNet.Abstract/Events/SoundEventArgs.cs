using System;

namespace ScriptDotNet
{
    public class SoundEventArgs : EventArgs
    {
        public SoundEventArgs(ushort soundId, ushort x, ushort y, short z)
        {
            SoundId = soundId;
            X = x;
            Y = y;
            Z = z;
        }
        public ushort SoundId { get; private set; }
        public ushort X { get; private set; }
        public ushort Y { get; private set; }
        public short Z { get; private set; }
    }


}
