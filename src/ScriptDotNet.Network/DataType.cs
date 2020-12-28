// -----------------------------------------------------------------------
// <copyright file="DataType.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ScriptDotNet.Network
{
    public enum DataType : byte
    {
        UnicodeString = 0,
        Cardinal = 1,
        Integer = 2,
        Word = 3,
        Smallint = 4,
        Byte = 5,
        ShortInt = 6,
        Boolean = 7,
    }
}
