using ScriptDotNet.Network;
using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet.Services
{
    public class MarketService : BaseService, IMarketService
    {
        public MarketService(IStealthClient client)
            : base(client)
        {

        }

        public ushort AutoBuyDelay
        {
            get
            {
                return _client.SendPacket<ushort>(PacketType.SCGetAutoBuyDelay);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetAutoBuyDelay, value);
            }
        }

        public ushort AutoSellDelay
        {
            get
            {
                return _client.SendPacket<ushort>(PacketType.SCGetAutoSellDelay);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetAutoSellDelay, value);
            }
        }

        public List<string> ShopList
        {
            get
            {
                return _client.SendPacket<string>(PacketType.SCGetShopList).Split("\r\n".ToCharArray())
                    .Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public void AutoBuy(ushort itemType, ushort itemColor, ushort quantity)
        {
            _client.SendPacket(PacketType.SCAutoBuy, itemType, itemColor, quantity);
        }

        public void AutoBuyEx(ushort itemType, ushort itemColor, ushort quantity, uint price, string name)
        {
            _client.SendPacket(PacketType.SCAutoBuyEx, itemType, itemColor, quantity, price, name);
        }

        public void AutoSell(ushort itemType, ushort itemColor, ushort quantity)
        {
            _client.SendPacket(PacketType.SCAutoSell, itemType, itemColor, quantity);
        }

        public void ClearShopList()
        {
            _client.SendPacket(PacketType.SCClearShopList);
        }
    }
}
