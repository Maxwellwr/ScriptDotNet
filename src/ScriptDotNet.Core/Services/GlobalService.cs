// -----------------------------------------------------------------------
// <copyright file="GlobalService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class GlobalService : BaseService, IGlobalService
    {
        public GlobalService(IStealthClient client)
            : base(client)
        {
        }

        public void SetGlobal(VarRegion globalRegion, string varName, string varValue)
        {
            Client.SendPacket(PacketType.SCSetGlobal, globalRegion, varName, varValue);
        }

        public string GetGlobal(VarRegion globalRegion, string varName)
        {
            return Client.SendPacket<string>(PacketType.SCGetGlobal, globalRegion, varName);
        }
    }
}
