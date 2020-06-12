using ScriptDotNet.Network;
using System;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class SkillSpellService:BaseService, ISkillSpellService
    {
        private Dictionary<string, int> _skills = new Dictionary<string, int>();

        private readonly ITargetService _targetService;

        public SkillSpellService(IStealthClient client, ITargetService targetService)
            :base(client)
        {
            _targetService = targetService;
        }

        public string ActiveAbility
        {
            get { return _client.SendPacket<string>(PacketType.SCGetAbility); }
        }

        public uint LastStatus
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastStatus); }
        }

        public bool Cast(string spellName)
        {
            Spell val;
            if (!Enum.TryParse(spellName, out val))
                return false;

            return Cast(val);
        }

        public bool Cast(Spell spell)
        {
            if (spell == Spell.none)
                return false;
            _client.SendPacket(PacketType.SCCastSpell, (uint)spell);
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
                result = _skills.TryGetValue(skillName, out val);

            if (!result)
            {
                skillId = _client.SendPacket<int>(PacketType.SCGetSkillID, skillName);
                result = skillId < 250;
                if (result)
                    _skills[skillName] = skillId;

            }
            else
                skillId = val;
            return result;
        }

        public double GetSkillCap(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
                return -1;
            return _client.SendPacket<double>(PacketType.SCGetSkillCap, skillId);
        }

        public double GetSkillValue(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
                return -1;
            return _client.SendPacket<double>(PacketType.SCSkillValue, skillId);
        }

        public double GetSkillCurrentValue(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
                return -1;
            return _client.SendPacket<double>(PacketType.SCSkillCurrentValue, skillId);
        }

        public bool IsActiveSpellAbility(string spellName)
        {
            Spell val;
            if (!Enum.TryParse(spellName, out val))
                return false;
            return Cast(val);
        }

        public void ReqVirtuesGump()
        {
            _client.SendPacket(PacketType.SCReqVirtuesGump);
        }

        public void SetStatState(byte statNum, byte statState)
        {
            _client.SendPacket(PacketType.SCChangeStatLockState, statNum, statState);
        }

        public void SkillLockState(string skillName, byte skillState)
        {
            int skillId;
            if (GetSkillId(skillName, out skillId))
                _client.SendPacket(PacketType.SCChangeSkillLockState, skillId, skillState);
            else
                throw new ArgumentNullException("skillName", "Can't find skill with name: " + skillName);
        }

        public void ToggleFly()
        {
            _client.SendPacket(PacketType.SCToggleFly);
        }

        public void UseOtherPaperdollScroll(uint id)
        {
            _client.SendPacket(PacketType.SCUseOtherPaperdollScroll, id);
        }

        public void UsePrimaryAbility()
        {
            _client.SendPacket(PacketType.SCUsePrimaryAbility);
        }

        public void UseSecondaryAbility()
        {
            _client.SendPacket(PacketType.SCUseSecondaryAbility);
        }

        public void UseSelfPaperdollScroll()
        {
            _client.SendPacket(PacketType.SCUseSelfPaperdollScroll);
        }

        public bool UseSkill(string skillName)
        {
            int skillId;
            if (!GetSkillId(skillName, out skillId))
                return false;

            _client.SendPacket(PacketType.SCUseSkill, skillId);
            return true;
        }

        public void UseVirtue(string virtueName)
        {
            Virtue virtue;
            if (virtueName.GetEnum<Virtue>(out virtue))
                UseVirtue(virtue);
        }

        public void UseVirtue(Virtue virtue)
        {
            _client.SendPacket(PacketType.SCUseVirtue, (uint)virtue);
        }
    }
}
