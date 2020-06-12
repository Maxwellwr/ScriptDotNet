using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GumpPicTiled
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int GumpId;
        public int Page;
        public int ElemNum;
    }
}
