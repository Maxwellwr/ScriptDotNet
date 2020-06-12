using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Target Info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TargetInfo
    {

        public uint ID;
        public ushort Tile;
        public ushort X;
        public ushort Y;
        public sbyte Z;
    }
}
