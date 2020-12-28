// -----------------------------------------------------------------------
// <copyright file="IClientService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IClientService
    {
        bool ClientHide(uint iD);

        void ClientPrint(string text);

        void ClientPrintEx(uint senderID, ushort color, ushort font, string text);

        void CloseClientUIWindow(UIWindowType uIWindowType, uint iD);

        void UOSay(string text);

        void UOSayColor(string text, ushort color);
    }
}
