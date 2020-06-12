using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Tooltip
    {
        public uint Cliloc_ID;
        public int Page;
        public int ElemNum;
    }
}
