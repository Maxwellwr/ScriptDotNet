using ScriptDotNet.Network;
using System.Collections.Generic;
using System.IO;

namespace ScriptDotNet.Services
{
    public class GameObjectService:BaseService, IGameObjectService
    {
        public GameObjectService(IStealthClient client)
            :base(client)
        {

        }

        public void ClickOnObject(uint objectId)
        {
            _client.SendPacket(PacketType.SCClickOnObject, objectId);
        }

        public ushort GetColor(uint objId)
        {
            return _client.SendPacket<ushort>(PacketType.SCGetColor, objId);
        }

        public string GetCliloc(uint objId)
        {
            return GetTooltip(objId);
        }

        public string GetClilocByID(uint clilocId)
        {
            return _client.SendPacket<string>(PacketType.SCGetClilocByID, clilocId);
        }

        public int GetDex(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetDex, objId);
        }

        public byte GetDirection(uint objId)
        {
            return _client.SendPacket<byte>(PacketType.SCGetDirection, objId);
        }

        public int GetDistance(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetDistance, objId);
        }

        public int GetHP(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetHP, objId);
        }

        public int GetInt(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetInt, objId);
        }

        public int GetMana(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetMana, objId);
        }

        public int GetMaxHP(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetMaxHP, objId);
        }

        public int GetMaxMana(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetMaxMana, objId);
        }

        public int GetMaxStam(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetMaxStam, objId);
        }

        public string GetName(uint objId)
        {
            return _client.SendPacket<string>(PacketType.SCGetName, objId);
        }

        public byte GetNotoriety(uint objId)
        {
            return _client.SendPacket<byte>(PacketType.SCGetNotoriety, objId);
        }

        public uint GetParent(uint objId)
        {
            return _client.SendPacket<uint>(PacketType.SCGetParent, objId);
        }

        public int GetQuantity(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetQuantity, objId);
        }

        public int GetStam(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetStam, objId);
        }

        public System.Drawing.Bitmap GetStaticArt(uint objType, ushort objColor)
        {
            var res = _client.SendPacket<byte[]>(PacketType.SCGetStaticArtBitmap, objType, objColor);

            if (res == null || res.Length == 0)
                return null;

            MemoryStream ms = new MemoryStream(res);
            return new System.Drawing.Bitmap(ms);
        }

        public int GetStr(uint objId)
        {
            return _client.SendPacket<int>(PacketType.SCGetStr, objId);
        }

        public string GetTooltip(uint objId)
        {
            return _client.SendPacket<string>(PacketType.SCGetCliloc, objId);
        }

        public List<ClilocItemRec> GetTooltipRec(uint objId)
        {
            return _client.SendPacket<List<ClilocItemRec>>(PacketType.SCGetToolTipRec, objId);
        }

        public ushort GetType(uint objId)
        {
            return _client.SendPacket<ushort>(PacketType.SCGetType, objId);
        }

        public ushort GetX(uint objId)
        {
            return _client.SendPacket<ushort>(PacketType.SCGetX, objId);
        }
        public ushort GetY(uint objId)
        {
            return _client.SendPacket<ushort>(PacketType.SCGetY, objId);
        }
        public sbyte GetZ(uint objId)
        {
            return _client.SendPacket<sbyte>(PacketType.SCGetZ, objId);
        }

        public bool IsContainer(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsContainer, objId);
        }

        public bool IsDead(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsDead, objId);
        }

        public bool IsFemale(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsFemale, objId);
        }

        public bool IsHidden(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsHidden, objId);
        }

        public bool IsMovable(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsMovable, objId);
        }

        public bool IsNPC(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsNPC, objId);
        }

        public bool IsObjectExists(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsObjectExists, objId);
        }

        public bool IsParalyzed(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsParalyzed, objId);
        }

        public bool IsPoisoned(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsPoisoned, objId);
        }

        public bool IsRunning(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsRunning, objId);
        }

        public bool IsWarMode(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsWarMode, objId);
        }

        public bool IsYellowHits(uint objId)
        {
            return _client.SendPacket<bool>(PacketType.SCIsYellowHits, objId);
        }

        public bool MobileCanBeRenamed(uint mobId)
        {
            return _client.SendPacket<bool>(PacketType.SCMobileCanBeRenamed, mobId);
        }

        public void RenameMobile(uint mobId, string newName)
        {
            _client.SendPacket(PacketType.SCRenameMobile, mobId, newName);
        }

        public uint UseFromGround(ushort objType, ushort color)
        {
            return _client.SendPacket<uint>(PacketType.SCUseFromGround, objType, color);
        }

        public void UseObject(uint objId)
        {
            _client.SendPacket(PacketType.SCUseObject, objId);
        }

        public uint UseType(ushort objType, ushort color = 0xFFFF)
        {
            return _client.SendPacket<uint>(PacketType.SCUseType, objType, color);
        }
    }
}
