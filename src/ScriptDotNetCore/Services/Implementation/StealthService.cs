using ScriptDotNet2.Data;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class StealthService:BaseService, IStealthService
    {
        public StealthService(StealthClient client)
            :base(client)
        {

        }

        public string CurrentScriptPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public string ProfileName
        {
            get { return _client.SendPacket<string>(PacketType.SCGetProfileName); }
        }

        public string ProfileShardName
        {
            get { return _client.SendPacket<string>(PacketType.SCGetProfileShardName); }
        }

        public AboutData StealthInfo
        {
            get { return _client.SendPacket<AboutData>(PacketType.SCGetStealthInfo); }
        }

        public string StealthPath
        {
            get { return _client.SendPacket<string>(PacketType.SCGetStealthPath); }
        }

        public string StealthProfilePath
        {
            get { return _client.SendPacket<string>(PacketType.SCGetStealthProfilePath); }
        }

        public uint StealthSelf
        {
            get { throw new NotImplementedException(); }
        }

        public string ShardName
        {
            get { return _client.SendPacket<string>(PacketType.SCGetShardName); }
        }

        public string ShardPath
        {
            get { return _client.SendPacket<string>(PacketType.SCGetShardPath); }
        }

        public void PauseCurrentScript()
        {
            throw new NotImplementedException();
        }

    }
}
