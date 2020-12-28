// -----------------------------------------------------------------------
// <copyright file="IMapService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IMapService
    {
        uint AddFigure(MapFigure figure);

        void ClearFigures();

        bool RemoveFigure(uint id);

        bool UpdateFigure(uint id, MapFigure figure);
    }
}
