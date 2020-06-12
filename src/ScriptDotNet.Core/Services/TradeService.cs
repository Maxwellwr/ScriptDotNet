using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class TradeService:BaseService, ITradeService
    {
        public TradeService(IStealthClient client)
            :base(client)
        {

        }

        public bool IsTrade
        {
            get { return _client.SendPacket<bool>(PacketType.SCCheckTradeState); }
        }

        public byte TradeCount
        {
            get { return _client.SendPacket<byte>(PacketType.SCGetTradeCount); }
        }

        public bool CancelTrade(byte tradeNum)
        {
            return _client.SendPacket<bool>(PacketType.SCCancelTrade, tradeNum);
        }

        public void ConfirmTrade(byte tradeNum)
        {
            _client.SendPacket(PacketType.SCConfirmTrade, tradeNum);
        }

        public uint GetTradeContainer(byte tradeNum, byte num)
        {
            return _client.SendPacket<uint>(PacketType.SCGetTradeContainer, tradeNum, num);
        }

        public uint GetTradeOpponent(byte tradeNum)
        {
            return _client.SendPacket<uint>(PacketType.SCGetTradeOpponent, tradeNum);
        }

        public string GetTradeOpponentName(byte tradeNum)
        {
            return _client.SendPacket<string>(PacketType.SCGetTradeOpponentName, tradeNum);
        }

        public bool TradeCheck(byte tradeNum, byte num)
        {
            return _client.SendPacket<bool>(PacketType.SCTradeCheck, tradeNum, num);
        }
    }
}
