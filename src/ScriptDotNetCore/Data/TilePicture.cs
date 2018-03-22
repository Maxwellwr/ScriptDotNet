using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet2.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TilePicture
    {
        public int X;
        public int Y;
        public int Id;
        public int Color;
        public int Page;
        public int ElemNum;
    }
}
