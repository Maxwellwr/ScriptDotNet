// -----------------------------------------------------------------------
// <copyright file="IStealthService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IStealthService
    {
        string CurrentScriptPath { get; }

        string ProfileName { get; }

        string ProfileShardName { get; }

        AboutData StealthInfo { get; }

        string StealthPath { get; }

        string StealthProfilePath { get; }

        uint StealthSelf { get; }

        string ShardName { get; }

        string ShardPath { get; }

        void PauseCurrentScript();
    }
}
