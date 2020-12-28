// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace ScriptDotNet
{
    public static class Extensions
    {
        public static bool GetEnum<T>(this string name, out T result)
            where T : struct
        {
            return Enum.TryParse<T>(name.Replace(" ", string.Empty), true, out result);
        }
    }
}
