namespace ScriptDotNet.Services
{
    public interface IClientService
    {
        bool ClientHide(uint ID);
        void ClientPrint(string Text);
        void ClientPrintEx(uint SenderID, ushort Color, ushort Font, string Text);
        void CloseClientUIWindow(UIWindowType UIWindowType, uint ID);
        void UOSay(string Text);
        void UOSayColor(string Text, ushort Color);
        
    }
}
