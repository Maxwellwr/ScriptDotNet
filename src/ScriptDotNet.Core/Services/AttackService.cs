using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class AttackService:BaseService, IAttackService
    {
        private readonly ICharStatsService _charStatsService;
        private readonly IGameObjectService _gameObjectService;

        public AttackService(IStealthClient client, ICharStatsService charStatsService, IGameObjectService gameObjectService)
            :base(client)
        {
            _charStatsService = charStatsService;
            _gameObjectService = gameObjectService;
        }

        public uint LastAttack
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastAttack); }
        }

        public bool WarMode
        {
            get
            {
                return _gameObjectService.IsWarMode(_charStatsService.Self);
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
