using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TilePic
    {
        public int X;
        public int Y;
        public int Id;
        public int Page;
        public int ElemNum;
    }
}
