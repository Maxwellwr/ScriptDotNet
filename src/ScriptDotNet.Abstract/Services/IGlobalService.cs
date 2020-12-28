// -----------------------------------------------------------------------
// <copyright file="IGlobalService.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Services
{
    public interface IGlobalService
    {
        string GetGlobal(VarRegion globalRegion, string varName);

        void SetGlobal(VarRegion globalRegion, string varName, string varValue);
    }
}
