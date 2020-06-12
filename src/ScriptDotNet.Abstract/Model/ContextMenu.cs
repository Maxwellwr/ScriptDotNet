using System.Collections.Generic;

namespace ScriptDotNet
{
    public struct ContextMenu
    {
        public uint ID { get; set; }
        public byte EntriesNumber { get; set; }
        public bool NewCliloc { get; set; }
        public List<ContextMenuEntry> Entries { get; set; }
    }
}
