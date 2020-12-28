// -----------------------------------------------------------------------
// <copyright file="PartyService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class PartyService : BaseService, IPartyService
    {
        public PartyService(IStealthClient client)
            : base(client)
        {
        }

        public bool InParty
        {
            get { return Client.SendPacket<bool>(PacketType.SCInParty); }
        }

        public uint[] PartyMembersList
        {
            get { return Client.SendPacket<uint[]>(PacketType.SCPartyMembersList); }
        }

        public void InviteToParty(uint id)
        {
            Client.SendPacket(PacketType.SCInviteToParty, id);
        }

        public void PartyAcceptInvite()
        {
            Client.SendPacket(PacketType.SCPartyAcceptInvite);
        }

        public void PartyCanLootMe(bool value)
        {
            Client.SendPacket(PacketType.SCPartyCanLootMe, value);
        }

        public void PartyDeclineInvite()
        {
            Client.SendPacket(PacketType.SCPartyDeclineInvite);
        }

        public void PartyLeave()
        {
            Client.SendPacket(PacketType.SCPartyLeave);
        }

        public void PartyPrivateMessageTo(uint id, string msg)
        {
            Client.SendPacket(PacketType.SCPartyMessageTo, id, msg);
        }

        public void PartySay(string msg)
        {
            Client.SendPacket(PacketType.SCPartySay, msg);
        }

        public void RemoveFromParty(uint id)
        {
            Client.SendPacket(PacketType.SCRemoveFromParty, id);
        }
    }
}
