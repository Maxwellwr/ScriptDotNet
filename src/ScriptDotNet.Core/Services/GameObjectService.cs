// -----------------------------------------------------------------------
// <copyright file="GameObjectService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System.Collections.Generic;
using System.IO;

namespace ScriptDotNet.Services
{
    public class GameObjectService : BaseService, IGameObjectService
    {
        public GameObjectService(IStealthClient client)
            : base(client)
        {
        }

        public void ClickOnObject(uint objectId)
        {
            Client.SendPacket(PacketType.SCClickOnObject, objectId);
        }

        public ushort GetColor(uint objId)
        {
            return Client.SendPacket<ushort>(PacketType.SCGetColor, objId);
        }

        public string GetCliloc(uint objId)
        {
            return GetTooltip(objId);
        }

        public string GetClilocByID(uint clilocId)
        {
            return Client.SendPacket<string>(PacketType.SCGetClilocByID, clilocId);
        }

        public int GetDex(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetDex, objId);
        }

        public byte GetDirection(uint objId)
        {
            return Client.SendPacket<byte>(PacketType.SCGetDirection, objId);
        }

        public int GetDistance(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetDistance, objId);
        }

        public int GetHP(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetHP, objId);
        }

        public int GetInt(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetInt, objId);
        }

        public int GetMana(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetMana, objId);
        }

        public int GetMaxHP(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetMaxHP, objId);
        }

        public int GetMaxMana(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetMaxMana, objId);
        }

        public int GetMaxStam(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetMaxStam, objId);
        }

        public string GetName(uint objId)
        {
            return Client.SendPacket<string>(PacketType.SCGetName, objId);
        }

        public byte GetNotoriety(uint objId)
        {
            return Client.SendPacket<byte>(PacketType.SCGetNotoriety, objId);
        }

        public uint GetParent(uint objId)
        {
            return Client.SendPacket<uint>(PacketType.SCGetParent, objId);
        }

        public int GetQuantity(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetQuantity, objId);
        }

        public int GetStam(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetStam, objId);
        }

        public System.Drawing.Bitmap GetStaticArt(uint objType, ushort objColor)
        {
            var res = Client.SendPacket<byte[]>(PacketType.SCGetStaticArtBitmap, objType, objColor);

            if (res == null || res.Length == 0)
            {
                return null;
            }

            MemoryStream ms = new MemoryStream(res);
            return new System.Drawing.Bitmap(ms);
        }

        public int GetStr(uint objId)
        {
            return Client.SendPacket<int>(PacketType.SCGetStr, objId);
        }

        public string GetTooltip(uint objId)
        {
            return Client.SendPacket<string>(PacketType.SCGetCliloc, objId);
        }

        public List<ClilocItemRec> GetTooltipRec(uint objId)
        {
            return Client.SendPacket<List<ClilocItemRec>>(PacketType.SCGetToolTipRec, objId);
        }

        public ushort GetType(uint objId)
        {
            return Client.SendPacket<ushort>(PacketType.SCGetType, objId);
        }

        public ushort GetX(uint objId)
        {
            return Client.SendPacket<ushort>(PacketType.SCGetX, objId);
        }

        public ushort GetY(uint objId)
        {
            return Client.SendPacket<ushort>(PacketType.SCGetY, objId);
        }

        public sbyte GetZ(uint objId)
        {
            return Client.SendPacket<sbyte>(PacketType.SCGetZ, objId);
        }

        public bool IsContainer(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsContainer, objId);
        }

        public bool IsDead(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsDead, objId);
        }

        public bool IsFemale(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsFemale, objId);
        }

        public bool IsHidden(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsHidden, objId);
        }

        public bool IsMovable(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsMovable, objId);
        }

        public bool IsNPC(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsNPC, objId);
        }

        public bool IsObjectExists(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsObjectExists, objId);
        }

        public bool IsParalyzed(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsParalyzed, objId);
        }

        public bool IsPoisoned(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsPoisoned, objId);
        }

        public bool IsRunning(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsRunning, objId);
        }

        public bool IsWarMode(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsWarMode, objId);
        }

        public bool IsYellowHits(uint objId)
        {
            return Client.SendPacket<bool>(PacketType.SCIsYellowHits, objId);
        }

        public bool MobileCanBeRenamed(uint mobId)
        {
            return Client.SendPacket<bool>(PacketType.SCMobileCanBeRenamed, mobId);
        }

        public void RenameMobile(uint mobId, string newName)
        {
            Client.SendPacket(PacketType.SCRenameMobile, mobId, newName);
        }

        public uint UseFromGround(ushort objType, ushort color)
        {
            return Client.SendPacket<uint>(PacketType.SCUseFromGround, objType, color);
        }

        public void UseObject(uint objId)
        {
            Client.SendPacket(PacketType.SCUseObject, objId);
        }

        public uint UseType(ushort objType, ushort color = 0xFFFF)
        {
            return Client.SendPacket<uint>(PacketType.SCUseType, objType, color);
        }
    }
}
