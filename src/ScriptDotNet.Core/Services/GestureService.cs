// -----------------------------------------------------------------------
// <copyright file="GestureService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class GestureService : BaseService, IGestureService
    {
        public GestureService(IStealthClient client)
            : base(client)
        {
        }

        public void Bow()
        {
            Client.SendPacket(PacketType.SCBow);
        }

        public void Salute()
        {
            Client.SendPacket(PacketType.SCSalute);
        }
    }
}
