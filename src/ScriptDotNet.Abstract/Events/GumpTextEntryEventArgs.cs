using System;

namespace ScriptDotNet
{
    public class GumpTextEntryEventArgs : EventArgs
    {
        public GumpTextEntryEventArgs(int gumpTextEntryId, string title, byte inputStyle, int maxValue, string title2)
        {
            GumpTextEntryID = gumpTextEntryId;
            Title = title;
            InputStyle = inputStyle;
            MaxValue = maxValue;
            Title2 = title2;
        }

        public int GumpTextEntryID { get; private set; }
        public string Title { get; set; }
        public byte InputStyle { get; set; }
        public int MaxValue { get; set; }
        public string Title2 { get; set; }
    }


}
