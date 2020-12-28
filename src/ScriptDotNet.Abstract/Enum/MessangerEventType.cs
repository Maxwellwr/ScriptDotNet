// -----------------------------------------------------------------------
// <copyright file="MessangerEventType.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public enum MessangerEventType : byte
    {
        Connected = 0,
        Disconnected = 1,
        Message = 2,
        Error = 3,
    }
}
