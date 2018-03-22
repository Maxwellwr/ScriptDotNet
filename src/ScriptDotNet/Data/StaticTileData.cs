using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
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
