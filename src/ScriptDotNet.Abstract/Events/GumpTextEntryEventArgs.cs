using System;

namespace ScriptDotNet
{
    public class GumpTextEntryEventArgs : EventArgs
    {
        public GumpTextEntryEventArgs(uint gumpTextEntryId, string title, byte inputStyle, uint maxValue, string title2)
        {
            GumpTextEntryID = gumpTextEntryId;
            Title = title;
            InputStyle = inputStyle;
            MaxValue = maxValue;
            Title2 = title2;
        }

        public uint GumpTextEntryID { get; private set; }
        public string Title { get; set; }
        public byte InputStyle { get; set; }
        public uint MaxValue { get; set; }
        public string Title2 { get; set; }
    }


}
