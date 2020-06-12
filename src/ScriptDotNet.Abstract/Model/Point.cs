using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Point
    {

        public int X;
        public int Y;
    }
}
