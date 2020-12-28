// -----------------------------------------------------------------------
// <copyright file="ClilocSpeechAffixEventArgs.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet
{
    public class ClilocSpeechAffixEventArgs : ClilocSpeechEventArgs
    {
        public ClilocSpeechAffixEventArgs(uint senderId, string senderName, uint clilocId, string affix, string text)
            : base(senderId, senderName, clilocId, text)
        {
            Affix = affix;
        }

        public string Affix { get; private set; }
    }
}
