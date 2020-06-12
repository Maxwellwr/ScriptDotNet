using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Map Cell
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapCell
    {

        public ushort Tile;
        public sbyte Z;
    }
}
