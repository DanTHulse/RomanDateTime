using System;

namespace RomanDate.Extensions
{
    internal static partial class EnumEx
    {
        internal static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) - 1;

            return (j < 0) ? arr[arr.Length - 1] : arr[j];
        }
    }
}