// -----------------------------------------------------------------------
// <copyright file="MarketService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
                return Client.SendPacket<ushort>(PacketType.SCGetAutoBuyDelay);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetAutoBuyDelay, value);
            }
        }

        public ushort AutoSellDelay
        {
            get
            {
                return Client.SendPacket<ushort>(PacketType.SCGetAutoSellDelay);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetAutoSellDelay, value);
            }
        }

        public List<string> ShopList
        {
            get
            {
                return Client.SendPacket<string>(PacketType.SCGetShopList).Split("\r\n".ToCharArray())
                    .Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public void AutoBuy(ushort itemType, ushort itemColor, ushort quantity)
        {
            Client.SendPacket(PacketType.SCAutoBuy, itemType, itemColor, quantity);
        }

        public void AutoBuyEx(ushort itemType, ushort itemColor, ushort quantity, uint price, string name)
        {
            Client.SendPacket(PacketType.SCAutoBuyEx, itemType, itemColor, quantity, price, name);
        }

        public void AutoSell(ushort itemType, ushort itemColor, ushort quantity)
        {
            Client.SendPacket(PacketType.SCAutoSell, itemType, itemColor, quantity);
        }

        public void ClearShopList()
        {
            Client.SendPacket(PacketType.SCClearShopList);
        }
    }
}
