// -----------------------------------------------------------------------
// <copyright file="IStealthClient.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet.Network
{
    public interface IStealthClient : IDisposable
    {
        event EventHandler<ServerEventArgs> ServerEventRecieve;

        event EventHandler StartStopRecieve;

        event EventHandler TerminateRecieve;

        void Connect();

        void SendPacket(PacketType packetType, params object[] parameters);

        T SendPacket<T>(PacketType packetType, params object[] parameters);
    }
}