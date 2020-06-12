namespace ScriptDotNet.Services
{
    public interface IICQService
    {
        bool ICQConnected { get; }

        void ICQConnect(string UIN, string password);
        void ICQDisconnect();
        void ICQSendText(string DestinationUIN, string Text);
        void ICQSetStatus(byte Num);
        void ICQSetXStatus(byte Num);
    }
}
