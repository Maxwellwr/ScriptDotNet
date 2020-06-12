namespace ScriptDotNet
{
    public class Buff_DebuffSystemEventArgs : ObjectEventArgs
    {
        public Buff_DebuffSystemEventArgs(int objectId, ushort attributeId, bool isEnabled)
            : base(objectId)
        {
            AttributeId = attributeId;
            //Crome 31.12.2015 : Typo on assignment
            //IsEnabled = IsEnabled;
            IsEnabled = isEnabled;
        }
        public ushort AttributeId { get; private set; }
        public bool IsEnabled { get; private set; }
    }


}
