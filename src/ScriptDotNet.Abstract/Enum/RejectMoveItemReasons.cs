// -----------------------------------------------------------------------
// <copyright file="RejectMoveItemReasons.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public enum RejectMoveItemReason : byte
    {
        CanNotPickUp = 0,
        TooFarAway = 1,
        OutOfSight = 2,
        DoesNotBelong = 3,
        AlreadyHolding = 4,
        MustWait = 5,
    }
}
