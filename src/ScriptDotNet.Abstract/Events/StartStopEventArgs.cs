// -----------------------------------------------------------------------
// <copyright file="StartStopEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class StartStopEventArgs
    {
        public StartStopEventArgs(bool isStopped)
        {
            IsStopped = isStopped;
        }

        public bool IsStopped { get; private set; }
    }
}
