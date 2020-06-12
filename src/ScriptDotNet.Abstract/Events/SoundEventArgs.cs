using System;

namespace ScriptDotNet
{
    public class SoundEventArgs : EventArgs
    {
        public SoundEventArgs(ushort soundId, ushort x, ushort y, int z)
        {
            SoundId = soundId;
            X = x;
            Y = y;
            Z = z;
        }
        public ushort SoundId { get; private set; }
        public ushort X { get; private set; }
        public ushort Y { get; private set; }
        public int Z { get; private set; }
    }


}
