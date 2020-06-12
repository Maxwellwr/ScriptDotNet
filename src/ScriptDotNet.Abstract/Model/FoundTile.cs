using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Found Tile
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FoundTile
    {
        public ushort Tile;
        public ushort X;
        public ushort Y;
        public sbyte Z;

        public override bool Equals(object obj)
        {
            if (obj is FoundTile)
            {
                var ft = (FoundTile)obj;
                return ft.X == X && ft.Y == Y && ft.Z == Z;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }

    public class FoundTileComparer : IEqualityComparer<FoundTile>
    {
        public bool Equals(FoundTile x, FoundTile y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(FoundTile obj)
        {
            return obj.X.GetHashCode() ^ obj.Y.GetHashCode() ^ obj.Z.GetHashCode();
        }
    }
}
