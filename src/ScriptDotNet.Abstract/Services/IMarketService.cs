// -----------------------------------------------------------------------
// <copyright file="IMarketService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IMarketService
    {
        ushort AutoBuyDelay { get; set; }

        ushort AutoSellDelay { get; set; }

        List<string> ShopList { get; }

        void AutoBuy(ushort itemType, ushort itemColor, ushort quantity);

        void AutoBuyEx(ushort itemType, ushort itemColor, ushort quantity, uint price, string name);

        void AutoSell(ushort itemType, ushort itemColor, ushort quantity);

        void ClearShopList();
    }
}
