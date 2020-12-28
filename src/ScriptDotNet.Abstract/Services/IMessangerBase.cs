// -----------------------------------------------------------------------
// <copyright file="IMessangerBase.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet.Services
{
    public interface IMessangerBase
    {
        event EventHandler Connected;

        event EventHandler Disconnected;

        event EventHandler<MessangerTextEventArgs> IncomingMessage;

        event EventHandler<MessangerErrorEventArgs> Error;

        bool IsConnected { get; }

        string Token { get; }

        string Name { get; }

        void SendMessage(string message, string recieverId);

        void Connect(string token);
    }
}
