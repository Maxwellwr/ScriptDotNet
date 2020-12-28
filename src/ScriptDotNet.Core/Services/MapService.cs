// -----------------------------------------------------------------------
// <copyright file="MapService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using ScriptDotNet.Network;

using System;

namespace ScriptDotNet.Services
{
    public class MapService : BaseService, IMapService
    {
        public MapService(IStealthClient client)
            : base(client)
        {
        }

        public uint AddFigure(MapFigure figure)
        {
            throw new NotImplementedException();
        }

        public void ClearFigures()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFigure(uint id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFigure(uint id, MapFigure figure)
        {
            throw new NotImplementedException();
        }
    }
}
