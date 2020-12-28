// -----------------------------------------------------------------------
// <copyright file="StealthService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class StealthService : BaseService, IStealthService
    {
        public StealthService(IStealthClient client)
            : base(client)
        {
        }

        public string CurrentScriptPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public string ProfileName
        {
            get { return Client.SendPacket<string>(PacketType.SCGetProfileName); }
        }

        public string ProfileShardName
        {
            get { return Client.SendPacket<string>(PacketType.SCGetProfileShardName); }
        }

        public AboutData StealthInfo
        {
            get { return Client.SendPacket<AboutData>(PacketType.SCGetStealthInfo); }
        }

        public string StealthPath
        {
            get { return Client.SendPacket<string>(PacketType.SCGetStealthPath); }
        }

        public string StealthProfilePath
        {
            get { return Client.SendPacket<string>(PacketType.SCGetStealthProfilePath); }
        }

        public uint StealthSelf
        {
            get { throw new NotImplementedException(); }
        }

        public string ShardName
        {
            get { return Client.SendPacket<string>(PacketType.SCGetShardName); }
        }

        public string ShardPath
        {
            get { return Client.SendPacket<string>(PacketType.SCGetShardPath); }
        }

        public void PauseCurrentScript()
        {
            throw new NotImplementedException();
        }
    }
}
