// -----------------------------------------------------------------------
// <copyright file="AttackService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

namespace ScriptDotNet.Services
{
    public class AttackService : BaseService, IAttackService
    {
        private readonly ICharStatsService _charStatsService;
        private readonly IGameObjectService _gameObjectService;

        public AttackService(IStealthClient client, ICharStatsService charStatsService, IGameObjectService gameObjectService)
            : base(client)
        {
            _charStatsService = charStatsService;
            _gameObjectService = gameObjectService;
        }

        public uint LastAttack
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLastAttack); }
        }

        public bool WarMode
        {
            get
            {
                return _gameObjectService.IsWarMode(_charStatsService.Self);
            }

            set
            {
                Client.SendPacket(PacketType.SCSetWarMode, value);
            }
        }

        public uint WarTargetID
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetWarTarget); }
        }

        public void Attack(uint objectId)
        {
            Client.SendPacket(PacketType.SCAttack, objectId);
        }
    }
}
