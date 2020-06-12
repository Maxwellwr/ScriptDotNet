using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GumpText
    {
        public int X;
        public int Y;
        public int Color;
        public int TextId;
        public int Page;
        public int ElemNum;
    }
}
