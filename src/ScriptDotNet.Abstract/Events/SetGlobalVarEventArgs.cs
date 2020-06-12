using System;

namespace ScriptDotNet
{
    public class SetGlobalVarEventArgs : EventArgs
    {
        public SetGlobalVarEventArgs(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }


}
