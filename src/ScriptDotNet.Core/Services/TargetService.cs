// -----------------------------------------------------------------------
// <copyright file="TargetService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class TargetService : BaseService, ITargetService
    {
        public TargetService(IStealthClient client)
            : base(client)
        {
        }

        public TargetInfo ClientTargetResponse
        {
            get { return Client.SendPacket<TargetInfo>(PacketType.SCClientTargetResponse); }
        }

        public bool ClientTargetResponsePresent
        {
            get { return Client.SendPacket<bool>(PacketType.SCClientTargetResponsePresent); }
        }

        public uint TargetId
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetTargetID); }
        }

        public bool TargetPresent
        {
            get { return TargetId > 0; }
        }

        public uint LastTarget
        {
            get { return Client.SendPacket<uint>(PacketType.SCGetLastTarget); }
        }

        public void CancelTarget()
        {
            Client.SendPacket(PacketType.SCCancelTarget);
        }

        public void CancelWaitTarget()
        {
            Client.SendPacket(PacketType.SCCancelWaitTarget);
        }

        public bool CheckLOS(ushort xf, ushort yf, sbyte zf, ushort xt, ushort yt, sbyte zt, byte worldNum)
        {
            return Client.SendPacket<bool>(PacketType.SCCheckLOS, xf, yf, zf, xt, yt, zt, worldNum);
        }

        public void ClientRequestObjectTarget()
        {
            Client.SendPacket(PacketType.SCClientRequestObjectTarget);
        }

        public void ClientRequestTileTarget()
        {
            Client.SendPacket(PacketType.SCClientRequestTileTarget);
        }

        public void TargetToObject(uint objectID)
        {
            // 31.12.2015 Crome : I think we forgot to pass the ObjectID, correct?
            // _client.SendPacket(PacketType.SCTargetToObject);
            Client.SendPacket(PacketType.SCTargetToObject, objectID);
        }

        public void TargetToTile(ushort tileModel, ushort x, ushort y, sbyte z)
        {
            Client.SendPacket(PacketType.SCTargetToTile, tileModel, x, y, z);
        }

        public void TargetToXYZ(ushort x, ushort y, sbyte z)
        {
            Client.SendPacket(PacketType.SCTargetToXYZ, x, y, z);
        }

        public bool WaitForClientTargetResponse(int maxWaitTimeMS)
        {
            DateTime enddate = DateTime.Now.AddMilliseconds(maxWaitTimeMS);

            while (DateTime.Now < enddate && !ClientTargetResponsePresent)
            {
                Thread.Sleep(100);
            }

            return DateTime.Now < enddate && ClientTargetResponsePresent;
        }

        public bool WaitForTarget(int maxWaitTimeMS)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(maxWaitTimeMS);
            while (TargetId == 0 && DateTime.Now < endTime)
            {
                Thread.Sleep(10);
            }

            return DateTime.Now < endTime && TargetId > 0;
        }

        public void WaitTargetGround(ushort objType)
        {
            Client.SendPacket(PacketType.SCWaitTargetGround, objType);
        }

        public void WaitTargetLast()
        {
            Client.SendPacket(PacketType.SCWaitTargetLast);
        }

        public void WaitTargetObject(uint objId)
        {
            Client.SendPacket(PacketType.SCWaitTargetObject, objId);
        }

        public void WaitTargetSelf()
        {
            Client.SendPacket(PacketType.SCWaitTargetSelf);
        }

        public void WaitTargetTile(ushort tile, ushort x, ushort y, sbyte z)
        {
            Client.SendPacket(PacketType.SCWaitTargetTile, tile, x, y, z);
        }

        public void WaitTargetType(ushort objType)
        {
            Client.SendPacket(PacketType.SCWaitTargetType, objType);
        }

        public void WaitTargetXYZ(ushort x, ushort y, sbyte z)
        {
            Client.SendPacket(PacketType.SCWaitTargetXYZ, x, y, z);
        }
    }
}
