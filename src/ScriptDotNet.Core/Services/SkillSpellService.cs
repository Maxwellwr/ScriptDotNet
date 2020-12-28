// -----------------------------------------------------------------------
// <copyright file="SkillSpellService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class SkillSpellService : BaseService, ISkillSpellService
    {
        private readonly ITargetService _targetService;
        private Dictionary<string, int> _skills = new Dictionary<string, int>();

        public SkillSpellService(IStealthClient client, ITargetService targetService)
            : base(client)
        {
            _targetService = targetService;
        }

        public string ActiveAbility
        {
            get { return Client.SendPacket<string>(PacketType.SCGetAbility); }
        }

        public uint LastStatus
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLastStatus); }
        }

        public bool Cast(string spellName)
        {
            Spell val;
            if (!Enum.TryParse(spellName, out val))
            {
                return false;
            }

            return Cast(val);
        }

        public bool Cast(Spell spell)
        {
            if (spell == Spell.None)
            {
                return false;
            }

            Client.SendPacket(PacketType.SCCastSpell, (uint)spell);
            return true;
        }

        public bool CastSpellToObj(string spellName, uint objId)
        {
            _targetService.WaitTargetObject(objId);
            return Cast(spellName);
        }

        public bool CastSpellToObj(Spell spell, uint objId)
        {
            _targetService.WaitTargetObject(objId);
            return Cast(spell);
        }

        public bool GetSkillId(string skillName, out int skillId)
        {
            bool result = false;
            int val = 250;

            if (_skills.ContainsKey(skillName))
            {
                result = _skills.TryGetValue(skillName, out val);
            }

            if (!result)
            {
                skillId = Client.SendPacket<int>(PacketType.SCGetSkillID, skillName);
                result = skillId < 250;
                if (result)
                {
                    _skills[skillName] = skillId;
                }
            }
            else
            {
                skillId = val;
            }

            return result;
        }

        public double GetSkillCap(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
            {
                return -1;
            }

            return Client.SendPacket<double>(PacketType.SCGetSkillCap, skillId);
        }

        public double GetSkillValue(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
            {
                return -1;
            }

            return Client.SendPacket<double>(PacketType.SCSkillValue, skillId);
        }

        public double GetSkillCurrentValue(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
            {
                return -1;
            }

            return Client.SendPacket<double>(PacketType.SCSkillCurrentValue, skillId);
        }

        public bool IsActiveSpellAbility(string spellName)
        {
            Spell val;
            if (!Enum.TryParse(spellName, out val))
            {
                return false;
            }

            return Cast(val);
        }

        public void ReqVirtuesGump()
        {
            Client.SendPacket(PacketType.SCReqVirtuesGump);
        }

        public void SetStatState(byte statNum, byte statState)
        {
            Client.SendPacket(PacketType.SCChangeStatLockState, statNum, statState);
        }

        public void SkillLockState(string skillName, byte skillState)
        {
            int skillId;
            if (GetSkillId(skillName, out skillId))
            {
                Client.SendPacket(PacketType.SCChangeSkillLockState, skillId, skillState);
            }
            else
            {
                throw new ArgumentNullException("skillName", "Can't find skill with name: " + skillName);
            }
        }

        public void ToggleFly()
        {
            Client.SendPacket(PacketType.SCToggleFly);
        }

        public void UseOtherPaperdollScroll(uint id)
        {
            Client.SendPacket(PacketType.SCUseOtherPaperdollScroll, id);
        }

        public void UsePrimaryAbility()
        {
            Client.SendPacket(PacketType.SCUsePrimaryAbility);
        }

        public void UseSecondaryAbility()
        {
            Client.SendPacket(PacketType.SCUseSecondaryAbility);
        }

        public void UseSelfPaperdollScroll()
        {
            Client.SendPacket(PacketType.SCUseSelfPaperdollScroll);
        }

        public bool UseSkill(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
            {
                return false;
            }

            Client.SendPacket(PacketType.SCUseSkill, skillId);
            return true;
        }

        public void UseVirtue(string virtueName)
        {
            Virtue virtue;
            if (virtueName.GetEnum<Virtue>(out virtue))
            {
                UseVirtue(virtue);
            }
        }

        public void UseVirtue(Virtue virtue)
        {
            Client.SendPacket(PacketType.SCUseVirtue, (uint)virtue);
        }
    }
}
