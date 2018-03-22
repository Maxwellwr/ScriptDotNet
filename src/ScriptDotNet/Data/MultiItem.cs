using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet2
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultiItem
    {
        public uint ID { get; set; }
        public ushort X { get; set; }
        public ushort Y { get; set; }
        public sbyte Z { get; set; }

        public ushort XMin { get; set; }
        public ushort XMax { get; set; }
        public ushort YMin { get; set; }
        public ushort YMax { get; set; }

        public ushort Width { get; set; }
        public ushort Height { get; set; }
    }
}
