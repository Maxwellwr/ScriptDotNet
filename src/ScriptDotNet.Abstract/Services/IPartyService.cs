// -----------------------------------------------------------------------
// <copyright file="IPartyService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IPartyService
    {
        bool InParty { get; }

        uint[] PartyMembersList { get; }

        void InviteToParty(uint iD);

        void PartyAcceptInvite();

        void PartyCanLootMe(bool value);

        void PartyDeclineInvite();

        void PartyLeave();

        void PartyPrivateMessageTo(uint iD, string msg);

        void PartySay(string msg);

        void RemoveFromParty(uint iD);
    }
}
