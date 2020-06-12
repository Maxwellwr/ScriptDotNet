using System;

namespace ScriptDotNet
{
    public class GraphicalEffectEventArgs : EventArgs
    {
        public GraphicalEffectEventArgs(uint srcId, ushort srcX, ushort srcY, int srcZ, uint dstId, ushort dstX, ushort dstY, int dstZ, byte type, ushort itemId, byte fixedDir)
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

        public uint SrcId { get; private set; }
        public ushort SrcX { get; private set; }
        public ushort SrcY { get; private set; }
        public int SrcZ { get; private set; }
        public uint DstId { get; private set; }
        public ushort DstX { get; private set; }
        public ushort DstY { get; private set; }
        public int DstZ { get; private set; }
        public byte Type { get; private set; }
        public ushort ItemId { get; private set; }
        public byte FixedDir { get; private set; }
    }


}
