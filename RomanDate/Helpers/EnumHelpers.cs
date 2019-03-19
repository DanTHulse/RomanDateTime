using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanDate.Helpers
{
    public static class EnumHelpers
    {
        public static List<T> EnumToList<T>() where T : struct
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

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[]) Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) + 1;

            return (arr.Length == j) ? arr[0] : arr[j];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[]) Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) - 1;

            return (j < 0) ? arr[arr.Length - 1] : arr[j];
        }
    }
}