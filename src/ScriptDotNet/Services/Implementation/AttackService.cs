using Ninject;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class AttackService:BaseService, IAttackService
    {
        [Inject]
        public ICharStatsService Char { private get; set; }
        [Inject]
        public IGameObjectService GameObject{ private get; set; }

        public AttackService(StealthClient client)
            :base(client)
        {
        }

        public uint LastAttack
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastAttack); }
        }

        public bool WarMode
        {
            get
            {
                return GameObject.IsWarMode(Char.Self);
            }
            set
            {
                _client.SendPacket(PacketType.SCSetWarMode, value);
            }
        }

        public uint WarTargetID
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetWarTarget); }
        }

        public void Attack(uint objectId)
        {
            _client.SendPacket(PacketType.SCAttack, objectId);
        }
    }
}
