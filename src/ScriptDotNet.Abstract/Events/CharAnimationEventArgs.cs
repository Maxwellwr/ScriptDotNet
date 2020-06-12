namespace ScriptDotNet
{
    public class CharAnimationEventArgs : ObjectEventArgs
    {
        public CharAnimationEventArgs(uint objectId, uint action)
            : base(objectId)
        {
            Action = action;
        }
        public uint Action { get; private set; }
    }


}
