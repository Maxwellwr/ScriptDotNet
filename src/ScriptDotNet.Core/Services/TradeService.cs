// -----------------------------------------------------------------------
// <copyright file="TradeService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class TradeService : BaseService, ITradeService
    {
        public TradeService(IStealthClient client)
            : base(client)
        {
        }

        public bool IsTrade
        {
            get { return Client.SendPacket<bool>(PacketType.SCCheckTradeState); }
        }

        public byte TradeCount
        {
            get { return Client.SendPacket<byte>(PacketType.SCGetTradeCount); }
        }

        public bool CancelTrade(byte tradeNum)
        {
            return Client.SendPacket<bool>(PacketType.SCCancelTrade, tradeNum);
        }

        public void ConfirmTrade(byte tradeNum)
        {
            Client.SendPacket(PacketType.SCConfirmTrade, tradeNum);
        }

        public uint GetTradeContainer(byte tradeNum, byte num)
        {
            return Client.SendPacket<uint>(PacketType.SCGetTradeContainer, tradeNum, num);
        }

        public uint GetTradeOpponent(byte tradeNum)
        {
            return Client.SendPacket<uint>(PacketType.SCGetTradeOpponent, tradeNum);
        }

        public string GetTradeOpponentName(byte tradeNum)
        {
            return Client.SendPacket<string>(PacketType.SCGetTradeOpponentName, tradeNum);
        }

        public bool TradeCheck(byte tradeNum, byte num)
        {
            return Client.SendPacket<bool>(PacketType.SCTradeCheck, tradeNum, num);
        }
    }
}
