using System.IO;

namespace ScriptDotNet
{
    public interface IDeserialized
    {
        void Deserialize(BinaryReader data);
    }
}
