// -----------------------------------------------------------------------
// <copyright file="AboutData.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace ScriptDotNet
{
    /// <summary>
    /// About data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AboutData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public ushort[] StealthVersion;
        public ushort Build;
        public double BuildDate;
        public ushort GITRevNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] GITRevision;

        public DateTime BuildDateTime
        {
            get { return BuildDate.ToDateTime(); }
        }
    }
}
