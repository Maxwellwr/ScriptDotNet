using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Data
{
    /// <summary>
    /// My Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MyPoint
    {

        public ushort X;
        public ushort Y;
        public sbyte Z;
    }
}
