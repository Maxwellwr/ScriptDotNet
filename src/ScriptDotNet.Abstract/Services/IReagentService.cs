// -----------------------------------------------------------------------
// <copyright file="IReagentService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IReagentService
    {
        int BMCount { get; }

        int BPCount { get; }

        int GACount { get; }

        int GSCount { get; }

        int MRCount { get; }

        int NSCount { get; }

        int SACount { get; }

        int SSCount { get; }
    }
}
