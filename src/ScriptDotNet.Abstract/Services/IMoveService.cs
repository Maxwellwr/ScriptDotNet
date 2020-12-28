// -----------------------------------------------------------------------
// <copyright file="IMoveService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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

        ushort MoveThroughNPC { get; set; }

        int MoveTurnCost { get; set; }

        byte PredictedDirection { get; }

        ushort PredictedX { get; }

        ushort PredictedY { get; }

        sbyte PredictedZ { get; }

        void CalcCoord(ushort x, ushort y, Direction dir, out ushort x2, out ushort y2);

        Direction CalcDir(ushort xfrom, ushort yfrom, ushort xto, ushort yto);

        void ClearBadLocationList();

        void ClearBadObjectList();

        ushort Dist(ushort x1, ushort y1, ushort x2, ushort y2);

        List<MyPoint> GetPathArray(ushort destX, ushort destY, bool optimized, int accuracy);

        List<MyPoint> GetPathArray3D(ushort startX, ushort startY, sbyte startZ, ushort finishX, ushort finishY, sbyte finishZ, byte worldNum, int accuracyXY, int accuracyZ, bool run);

        uint GetLastStepQUsedDoor();

        bool MoveXY(ushort xDst, ushort yDst, bool optimized, int accuracy, bool running);

        bool MoveXYZ(ushort xDst, ushort yDst, sbyte zdst, int accuracyXY, int accuracyZ, bool running);

        bool NewMoveXY(ushort xDst, ushort yDst, bool optimized, int accuracy, bool running);

        void StopMover();

        void OpenDoor();

        bool RawMove(byte direction, bool running);

        void SetBadLocation(ushort x, ushort y);

        void SetBadObject(ushort objType, ushort color, byte radius);

        void SetGoodLocation(ushort x, ushort y);

        byte Step(byte direction, bool running);

        int StepQ(byte direction, bool running);
    }
}
