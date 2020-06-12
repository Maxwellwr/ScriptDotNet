using System;

namespace ScriptDotNet
{
    public class QuestArrowEventArgs : EventArgs
    {
        public QuestArrowEventArgs(ushort x, ushort y, bool isActive)
        {
            X = x;
            Y = y;
            IsActive = isActive;
        }
        public ushort X { get; private set; }
        public ushort Y { get; private set; }
        public bool IsActive { get; private set; }
    }


}
