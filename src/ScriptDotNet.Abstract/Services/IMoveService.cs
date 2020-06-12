using System.Collections.Generic;

namespace ScriptDotNet.Services
{
    public interface IMoveService
    {
        bool MoveBetweenTwoCorners { get; set; }
        ushort RunMountTimer { get; set; }
        ushort RunUnMountTimer { get; set; }
        ushort WalkMountTimer { get; set; }
        ushort WalkUnmountTimer { get; set; }
        ushort MoveCheckStamina { get; set; }
        int MoveHeuristicMult { get; set; }
        bool MoveOpenDoor { get; set; }
        bool MoveThroughCorner { get; set; }
        ushort MoveThroughNPC {get; set;}
        int MoveTurnCost { get; set; }
        byte PredictedDirection { get; }
        ushort PredictedX { get; }
        ushort PredictedY { get; }
        sbyte PredictedZ { get; }

        void CalcCoord(ushort x, ushort y, Direction dir, out ushort x2, out ushort y2);
        Direction CalcDir(ushort Xfrom, ushort Yfrom, ushort Xto, ushort Yto);
        void ClearBadLocationList();
        void ClearBadObjectList();
        ushort Dist(ushort X1, ushort Y1, ushort X2, ushort Y2);
        List<MyPoint> GetPathArray(ushort DestX, ushort DestY, bool optimized, int Accuracy);
        List<MyPoint> GetPathArray3D(ushort StartX, ushort StartY, sbyte StartZ, ushort FinishX, ushort FinishY, sbyte FinishZ, byte WorldNum, int AccuracyXY, int AccuracyZ, bool Run);
        uint GetLastStepQUsedDoor();
        bool MoveXY(ushort xDst, ushort yDst, bool optimized, int Accuracy, bool running);
        bool MoveXYZ(ushort xDst, ushort yDst, sbyte Zdst, int AccuracyXY, int AccuracyZ, bool running);
        bool NewMoveXY(ushort xDst, ushort yDst, bool optimized, int Accuracy, bool running);
        void OpenDoor();
        bool RawMove(byte direction, bool running);
        void SetBadLocation(ushort X, ushort Y);
        void SetBadObject(ushort ObjType, ushort Color, byte Radius);
        void SetGoodLocation(ushort X, ushort Y);
        byte Step(byte direction, bool running);
        int StepQ(byte direction, bool running);
    }
}
