// -----------------------------------------------------------------------
// <copyright file="MyPoint.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// My Point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MyPoint
    {
        public ushort X;
        public ushort Y;
        public sbyte Z;
    }
}
