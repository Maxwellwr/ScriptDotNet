namespace ScriptDotNet
{
    public class CharAnimationEventArgs : ObjectEventArgs
    {
        public CharAnimationEventArgs(int objectId, ushort action)
            : base(objectId)
        {
            Action = action;
        }
        public ushort Action { get; private set; }
    }


}
