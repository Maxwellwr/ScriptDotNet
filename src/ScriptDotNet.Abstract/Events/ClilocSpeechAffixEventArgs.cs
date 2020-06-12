namespace ScriptDotNet
{
    public class ClilocSpeechAffixEventArgs : ClilocSpeechEventArgs
    {
        public ClilocSpeechAffixEventArgs(int senderId, string senderName, int clilocId, string affix, string text)
            : base(senderId, senderName, clilocId, text)
        {
            Affix = affix;
        }
        public string Affix { get; private set; }
    }


}
