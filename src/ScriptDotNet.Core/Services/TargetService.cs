using ScriptDotNet.Network;
using System;
using System.Threading;

namespace ScriptDotNet.Services
{
    public class TargetService:BaseService, ITargetService
    {
        public TargetService(IStealthClient client)
            :base(client)
        {

        }

        public TargetInfo ClientTargetResponse
        {
            get { return _client.SendPacket<TargetInfo>(PacketType.SCClientTargetResponse); }
        }

        public bool ClientTargetResponsePresent
        {
            get { return _client.SendPacket<bool>(PacketType.SCClientTargetResponsePresent); }
        }

        public uint TargetId
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetTargetID); }
        }

        public bool TargetPresent
        {
            get { return TargetId > 0; }
        }

        public uint LastTarget
        {
            get { return _client.SendPacket<uint>(PacketType.SCGetLastTarget); }
        }

        public void CancelTarget()
        {
            _client.SendPacket(PacketType.SCCancelTarget);
        }

        public void CancelWaitTarget()
        {
            _client.SendPacket(PacketType.SCCancelWaitTarget);
        }

        public bool CheckLOS(ushort xf, ushort yf, sbyte zf, ushort xt, ushort yt, sbyte zt, byte worldNum)
        {
            return _client.SendPacket<bool>(PacketType.SCCheckLOS, xf, yf, zf, xt, yt, zt, worldNum);
        }

        public void ClientRequestObjectTarget()
        {
            _client.SendPacket(PacketType.SCClientRequestObjectTarget);
        }

        public void ClientRequestTileTarget()
        {
            _client.SendPacket(PacketType.SCClientRequestTileTarget);
        }

        public void TargetToObject(uint ObjectID)
        {
            //31.12.2015 Crome : I think we forgot to pass the ObjectID, correct?
            //_client.SendPacket(PacketType.SCTargetToObject);
            _client.SendPacket(PacketType.SCTargetToObject,ObjectID);
        }

        public void TargetToTile(ushort tileModel, ushort x, ushort y, sbyte z)
        {
            _client.SendPacket(PacketType.SCTargetToTile, tileModel, x, y, z);
        }

        public void TargetToXYZ(ushort x, ushort y, sbyte z)
        {
            _client.SendPacket(PacketType.SCTargetToXYZ, x, y, z);
        }

        public bool WaitForClientTargetResponse(int maxWaitTimeMS)
        {
            DateTime enddate = DateTime.Now.AddMilliseconds(maxWaitTimeMS);

            while (DateTime.Now < enddate && !ClientTargetResponsePresent)
            {
                Thread.Sleep(100);
            }

            return (DateTime.Now < enddate && ClientTargetResponsePresent);
        }

        public bool WaitForTarget(int maxWaitTimeMS)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(maxWaitTimeMS);
            while (TargetId == 0 && DateTime.Now < endTime)
                Thread.Sleep(10);

            return (DateTime.Now < endTime && TargetId > 0);
        }

        public void WaitTargetGround(ushort objType)
        {
            _client.SendPacket(PacketType.SCWaitTargetGround, objType);
        }

        public void WaitTargetLast()
        {
            _client.SendPacket(PacketType.SCWaitTargetLast);
        }

        public void WaitTargetObject(uint objId)
        {
            _client.SendPacket(PacketType.SCWaitTargetObject, objId);
        }

        public void WaitTargetSelf()
        {
            _client.SendPacket(PacketType.SCWaitTargetSelf);
        }

        public void WaitTargetTile(ushort tile, ushort x, ushort y, sbyte z)
        {
            _client.SendPacket(PacketType.SCWaitTargetTile, tile, x, y, z);
        }

        public void WaitTargetType(ushort objType)
        {
            _client.SendPacket(PacketType.SCWaitTargetType, objType);
        }

        public void WaitTargetXYZ(ushort x, ushort y, sbyte z)
        {
            _client.SendPacket(PacketType.SCWaitTargetXYZ, x, y, z);
        }
    }
}
