// -----------------------------------------------------------------------
// <copyright file="IInfoWindowService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IInfoWindowService
    {
        void ClearInfoWindow();

        void FillInfoWindow(string s);
    }
}
