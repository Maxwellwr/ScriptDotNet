﻿namespace ScriptDotNet
{
    public struct ContextMenuEntry
    {
        public ushort Tag { get; set; }
        public uint IntLocID { get; set; }
        public ushort Flags { get; set; }
        public ushort Color { get; set; }
    }
}
