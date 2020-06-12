using System;

namespace ScriptDotNet
{
    public class GraphicalEffectEventArgs : EventArgs
    {
        public GraphicalEffectEventArgs(int srcId, ushort srcX, ushort srcY, short srcZ, int dstId, ushort dstX, ushort dstY, short dstZ, byte type, ushort itemId, byte fixedDir)
        {
            SrcId = srcId;
            SrcX = srcX;
            SrcY = srcY;
            SrcZ = srcZ;
            DstId = dstId;
            DstX = dstX;
            DstY = dstY;
            DstZ = dstZ;
            Type = type;
            ItemId = itemId;
            FixedDir = fixedDir;
        }

        public int SrcId { get; private set; }
        public ushort SrcX { get; private set; }
        public ushort SrcY { get; private set; }
        public short SrcZ { get; private set; }
        public int DstId { get; private set; }
        public ushort DstX { get; private set; }
        public ushort DstY { get; private set; }
        public short DstZ { get; private set; }
        public byte Type { get; private set; }
        public ushort ItemId { get; private set; }
        public byte FixedDir { get; private set; }
    }


}
