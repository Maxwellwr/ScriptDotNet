using System;

namespace ScriptDotNet
{
    public class ObjectEventArgs : EventArgs
    {
        public ObjectEventArgs(int objectId)
        {
            ObjectId = objectId;
        }
        public int ObjectId { get; private set; }
    }


}
