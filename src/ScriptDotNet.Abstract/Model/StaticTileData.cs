using System;
using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StaticTileData
    {
        public ulong Flags;
        public int Weight;
        public int Height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] RadarColorRGBA;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public String Name;
    }
}
