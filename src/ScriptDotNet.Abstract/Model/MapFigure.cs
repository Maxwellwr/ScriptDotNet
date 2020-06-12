using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapFigure
    {
        public FigureKind Kind;
        public FigureCoord Coord;
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        public System.Drawing.Color BrushColor;
        public uint BrushStyle;
        public System.Drawing.Color Color;
        public string Text;
    }
}
