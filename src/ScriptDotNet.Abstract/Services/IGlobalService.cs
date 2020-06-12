namespace ScriptDotNet.Services
{
    public interface IGlobalService
    {
        string GetGlobal(VarRegion GlobalRegion, string VarName);
        void SetGlobal(VarRegion GlobalRegion, string VarName, string VarValue);
    }
}
