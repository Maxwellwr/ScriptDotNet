using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IMarketService
    {
        ushort AutoBuyDelay { get; set; }
        ushort AutoSellDelay { get; set; }
        List<string> ShopList { get; }

        void AutoBuy(ushort ItemType, ushort ItemColor, ushort Quantity);
        void AutoBuyEx(ushort ItemType, ushort ItemColor, ushort Quantity, uint Price, string Name);
        void AutoSell(ushort ItemType, ushort ItemColor, ushort Quantity);
        void ClearShopList();
    }
}
