// -----------------------------------------------------------------------
// <copyright file="InfoWindowService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class InfoWindowService : BaseService, IInfoWindowService
    {
        public InfoWindowService(IStealthClient client)
            : base(client)
        {
        }

        public void ClearInfoWindow()
        {
            Client.SendPacket(PacketType.SCClearInfoWindow);
        }

        public void FillInfoWindow(string str)
        {
            Client.SendPacket(PacketType.SCFillNewWindow, str);
        }
    }
}
