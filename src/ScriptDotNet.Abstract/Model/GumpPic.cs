using System.Runtime.InteropServices;

namespace ScriptDotNet
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GumpPic
    {
        public int X;
        public int Y;
        public int Id;
        public int Hue;
        public int Page;
        public int ElemNum;
    }
}
