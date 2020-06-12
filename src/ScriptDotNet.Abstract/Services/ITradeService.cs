namespace ScriptDotNet.Services
{
    public interface ITradeService
    {
        bool IsTrade { get; }
        byte TradeCount { get; }

        bool CancelTrade(byte TradeNum);
        void ConfirmTrade(byte TradeNum);
        uint GetTradeContainer(byte TradeNum, byte Num);
        uint GetTradeOpponent(byte TradeNum);
        string GetTradeOpponentName(byte TradeNum);
        bool TradeCheck(byte TradeNum, byte Num);
    }
}
