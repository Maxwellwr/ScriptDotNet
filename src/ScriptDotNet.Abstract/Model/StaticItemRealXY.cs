using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// StaticItemRealXY
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StaticItemRealXY
    {

        public ushort Tile;
        public ushort X;
        public ushort Y;
        public sbyte Z;
        public ushort Color;
    }
}
