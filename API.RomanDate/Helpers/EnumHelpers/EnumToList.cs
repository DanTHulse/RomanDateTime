using System;
using System.Collections.Generic;

namespace API.RomanDate.Helpers
{
    public static partial class EnumHelpers
    {
        public static List<T> EnumToList<T>() where T : struct
        {
            var enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("Type must be of type System.Enum");

            var enumValArray = Enum.GetValues(enumType);
            var enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
    }
}
