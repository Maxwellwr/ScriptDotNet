using System;

namespace ScriptDotNet
{
    public class ObjectEventArgs : EventArgs
    {
        public ObjectEventArgs(uint objectId)
        {
            ObjectId = objectId;
        }
        public uint ObjectId { get; private set; }
    }


}
