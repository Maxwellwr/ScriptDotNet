// -----------------------------------------------------------------------
// <copyright file="ISystemService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface ISystemService
    {
        bool SilentMode { get; set; }

        void Alarm();

        void Beep();

        void ConsoleEntryReply(string text);

        void ConsoleEntryUnicodeReply(string text);

        void HelpRequest();

        void QuestRequest();

        void RequestStats(uint objID);

        void SetCmdPrefix(char prefix);

        void ShowMessage(string msg);

        ushort Sign(int aValue);
    }
}
