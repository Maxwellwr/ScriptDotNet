// -----------------------------------------------------------------------
// <copyright file="IICQService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IICQService
    {
        bool ICQConnected { get; }

        void ICQConnect(string uIN, string password);

        void ICQDisconnect();

        void ICQSendText(string destinationUIN, string text);

        void ICQSetStatus(byte num);

        void ICQSetXStatus(byte num);
    }
}
