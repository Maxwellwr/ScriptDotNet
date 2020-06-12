using ScriptDotNet.Network;
using System;
using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public class MoveService : BaseService, IMoveService
    {
        public MoveService(IStealthClient client)
            : base(client)
        {

        }

        public bool MoveBetweenTwoCorners
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ushort RunMountTimer
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetRunMountTimer); }
            set { _client.SendPacket(PacketType.SCSetRunMountTimer, value); }
        }

        public ushort RunUnMountTimer
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetRunUnmountTimer); }
            set { _client.SendPacket(PacketType.SCSetRunUnmountTimer, value); }
        }

        public ushort WalkMountTimer
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetWalkMountTimer); }
            set { _client.SendPacket(PacketType.SCSetWalkMountTimer, value); }
        }

        public ushort WalkUnmountTimer
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetWalkUnmountTimer); }
            set { _client.SendPacket(PacketType.SCSetWalkUnmountTimer, value); }
        }

        public ushort MoveCheckStamina
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MoveHeuristicMult
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveOpenDoor
        {
            get { return _client.SendPacket<bool>(PacketType.SCGetMoveOpenDoor); }
            set { _client.SendPacket(PacketType.SCSetMoveOpenDoor, value); }
        }

        public bool MoveThroughCorner
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ushort MoveThroughNPC
        {
            get { return _client.SendPacket<ushort>(PacketType.SCGetMoveThroughNPC); }
            set { _client.SendPacket(PacketType.SCSetMoveThroughNPC, value); }
        }

        public int MoveTurnCost
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public byte PredictedDirection
        {
            get { return _client.SendPacket<byte>(PacketType.SCPredictedDirection); }
        }

        public ushort PredictedX
        {
            get { return _client.SendPacket<ushort>(PacketType.SCPredictedX); }
        }

        public ushort PredictedY
        {
            get { return _client.SendPacket<ushort>(PacketType.SCPredictedY); }
        }

        public sbyte PredictedZ
        {
            get { return _client.SendPacket<sbyte>(PacketType.SCPredictedZ); }
        }

        public void CalcCoord(ushort x, ushort y, Direction dir, out ushort x2, out ushort y2)
        {
            x2 = x;
            y2 = y;

            if ((dir == Direction.NorthEast) ||
                (dir == Direction.East) ||
                (dir == Direction.SouthEast))
                x2 = (ushort)(x + 1);
            if ((dir == Direction.SouthWest) ||
                (dir == Direction.West) || 
                (dir == Direction.NorthWest))
                x2 = (ushort)(x - 1);
            if ((dir == Direction.North) || 
                (dir == Direction.South)) 
                x2 = x;

            if ((dir == Direction.SouthEast) || 
                (dir == Direction.South) || 
                (dir == Direction.SouthWest)) 
                y2 = (ushort)(y + 1);
            if ((dir == Direction.NorthWest) || 
                (dir == Direction.North) || 
                (dir == Direction.NorthEast)) 
                y2 = (ushort)(y - 1);
            if ((dir == Direction.East) || 
                (dir == Direction.West)) 
                y2 = y;
        }

        public Direction CalcDir(ushort xFrom, ushort yFrom, ushort xTo, ushort yTo)
        {
            ushort diffx = (ushort)Math.Abs(xFrom - xTo);
            ushort diffy = (ushort)Math.Abs(yFrom - yTo);
            if (diffx == 0 && diffy == 0)
                return Direction.Unknown;
            if ((diffx / (diffy + 0.1)) >= 2)
            {
                if (xFrom > xTo) 
                    return Direction.West;
                return Direction.East;
            }
            if ((diffy / (diffx + 0.1)) >= 2)
            {
                if (yFrom > yTo) 
                    return Direction.North;
                return Direction.South;
            }
            if (xFrom > xTo && yFrom > yTo) 
                return Direction.NorthWest;
            if (xFrom > xTo && yFrom < yTo) 
                return Direction.SouthWest;
            if (xFrom < xTo && yFrom > yTo) 
                return Direction.NorthEast;
            if (xFrom < xTo && yFrom < yTo) 
                return Direction.SouthEast;
            return Direction.Unknown;
        }

        public void ClearBadLocationList()
        {
            _client.SendPacket(PacketType.SCClearBadLocationList);
        }

        public void ClearBadObjectList()
        {
            _client.SendPacket(PacketType.SCClearBadObjectList);
        }

        public ushort Dist(ushort x1, ushort y1, ushort x2, ushort y2)
        {
            var dx = (ushort)Math.Abs(x1 - x2);
            var dy = (ushort)Math.Abs(y1 - y2);

            var ret = (dx > dy) ? dy : dx;
            var my = (ushort)Math.Abs(dx - dy);
            return (ushort)(ret + my);
        }

        public List<MyPoint> GetPathArray(ushort destX, ushort destY, bool optimized, int accuracy)
        {
            return _client.SendPacket<List<MyPoint>>(PacketType.SCGetPathArray, destX, destY, optimized, accuracy);
        }

        public List<MyPoint> GetPathArray3D(ushort startX, ushort startY, sbyte startZ, ushort finishX, ushort finishY, sbyte finishZ, byte worldNum, int accuracyXY, int accuracyZ, bool run)
        {
            return _client.SendPacket<List<MyPoint>>(PacketType.SCGetPathArray3D, startX, startY, startZ, finishX, finishY, finishZ, worldNum, accuracyXY, accuracyZ, run);
        }

        public uint GetLastStepQUsedDoor()
        {
            return _client.SendPacket<uint>(PacketType.SCGetLastStepQUsedDoor);
        }

        public bool MoveXY(ushort xDst, ushort yDst, bool optimized, int accuracy, bool running)
        {
            return _client.SendPacket<bool>(PacketType.SCMoveXY, xDst, yDst, optimized, accuracy, running);
        }

        public bool MoveXYZ(ushort xDst, ushort yDst, sbyte zDst, int accuracyXY, int accuracyZ, bool running)
        {
            return _client.SendPacket<bool>(PacketType.SCMoveXYZ, xDst, yDst, zDst, accuracyXY, accuracyZ, running);
        }

        public bool NewMoveXY(ushort xDst, ushort yDst, bool optimized, int accuracy, bool running)
        {
            return MoveXYZ(xDst, yDst, 0, accuracy, 255, running);
        }

        public void OpenDoor()
        {
            _client.SendPacket(PacketType.SCOpenDoor);
        }

        public bool RawMove(byte direction, bool running)
        {
            throw new NotImplementedException();
        }

        public void SetBadLocation(ushort x, ushort y)
        {
            _client.SendPacket(PacketType.SCSetBadLocation, x, y);
        }

        public void SetBadObject(ushort objType, ushort color, byte radius)
        {
            _client.SendPacket(PacketType.SCSetBadObjects, objType, color, radius);
        }

        public void SetGoodLocation(ushort x, ushort y)
        {
            _client.SendPacket(PacketType.SCSetGoodLocation, x, y);
        }

        public byte Step(byte direction, bool running)
        {
            return _client.SendPacket<byte>(PacketType.SCStep, direction, running);
        }

        public int StepQ(byte direction, bool running)
        {
            return _client.SendPacket<int>(PacketType.SCStepQ, direction, running);
        }
    }
}
