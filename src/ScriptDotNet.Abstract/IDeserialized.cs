// -----------------------------------------------------------------------
// <copyright file="IDeserialized.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;

namespace ScriptDotNet
{
    public interface IDeserialized
    {
        void Deserialize(BinaryReader data);
    }
}
