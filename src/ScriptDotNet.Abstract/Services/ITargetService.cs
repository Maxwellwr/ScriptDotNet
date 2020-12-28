// -----------------------------------------------------------------------
// <copyright file="ITargetService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface ITargetService
    {
        TargetInfo ClientTargetResponse { get; }

        bool ClientTargetResponsePresent { get; }

        uint TargetId { get; }

        bool TargetPresent { get; }

        uint LastTarget { get; }

        void CancelTarget();

        void CancelWaitTarget();

        bool CheckLOS(ushort xf, ushort yf, sbyte zf, ushort xt, ushort yt, sbyte zt, byte worldNum);

        void ClientRequestObjectTarget();

        void ClientRequestTileTarget();

        void TargetToObject(uint objectID);

        void TargetToTile(ushort tileModel, ushort x, ushort y, sbyte z);

        void TargetToXYZ(ushort x, ushort y, sbyte z);

        bool WaitForClientTargetResponse(int maxWaitTimeMS);

        bool WaitForTarget(int maxWaitTimeMS);

        void WaitTargetGround(ushort objType);

        void WaitTargetLast();

        void WaitTargetObject(uint objID);

        void WaitTargetSelf();

        void WaitTargetTile(ushort tile, ushort x, ushort y, sbyte z);

        void WaitTargetType(ushort objType);

        void WaitTargetXYZ(ushort x, ushort y, sbyte z);
    }
}
