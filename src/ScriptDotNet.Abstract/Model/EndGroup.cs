using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EndGroup
    {
        public int GroupNumber;
        public int Page;
        public int ElemNum;
    }
}
