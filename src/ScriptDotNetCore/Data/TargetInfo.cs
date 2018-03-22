using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
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
