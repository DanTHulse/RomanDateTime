using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RomanDate.Helpers
{
    internal static class EnumHelpers
    {
        internal static string GetDescription<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }

        internal static List<T> EnumToList<T>() where T : struct
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T) Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        internal static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[]) Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) + 1;

            return (arr.Length == j) ? arr[0] : arr[j];
        }

        internal static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[]) Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) - 1;

            return (j < 0) ? arr[arr.Length - 1] : arr[j];
        }
    }
}