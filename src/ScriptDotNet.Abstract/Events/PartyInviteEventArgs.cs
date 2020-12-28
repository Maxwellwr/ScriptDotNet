// -----------------------------------------------------------------------
// <copyright file="PartyInviteEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public class PartyInviteEventArgs : EventArgs
    {
        public PartyInviteEventArgs(uint inviterId)
        {
            InviterId = inviterId;
        }

        public uint InviterId { get; private set; }
    }
}
