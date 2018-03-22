using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
{
    /// <summary>
    /// Land Tile Data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LandTileData
    {

        public uint Flags;
        public uint Flags2;
        public ushort TextureID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Name;
    }
}
