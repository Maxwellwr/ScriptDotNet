using System.Runtime.InteropServices;

namespace ScriptDotNet
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
