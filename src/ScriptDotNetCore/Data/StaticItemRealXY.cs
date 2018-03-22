using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
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
