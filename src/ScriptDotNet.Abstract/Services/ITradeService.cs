// -----------------------------------------------------------------------
// <copyright file="ITradeService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface ITradeService
    {
        bool IsTrade { get; }

        byte TradeCount { get; }

        bool CancelTrade(byte tradeNum);

        void ConfirmTrade(byte tradeNum);

        uint GetTradeContainer(byte tradeNum, byte num);

        uint GetTradeOpponent(byte tradeNum);

        string GetTradeOpponentName(byte tradeNum);

        bool TradeCheck(byte tradeNum, byte num);
    }
}
