using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptDotNet2.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RadioButton
    {
        public int X;
        public int Y;
        public int ReleasedId;
        public int PressedId;
        public int Status;
        public int ReturnValue;
        public int Page;
        public int ElemNum;
    }
}
