using System;
using System.ComponentModel;

namespace ScriptDotNet
{
    public static class Extensions
    {
        public static bool GetEnum<T>(this string name, out T result) where T : struct
        {
            return Enum.TryParse<T>(name.Replace(" ", ""), true, out result);
        }
    }
}
