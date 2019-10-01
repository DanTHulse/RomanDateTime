using System;
using System.Collections.Generic;

namespace API.RomanDate.Helpers
{
    public static partial class EnumHelpers
    {
        public static List<TEnum> EnumToList<TEnum>() where TEnum : struct
        {
            var enumType = typeof(TEnum);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("TEnum must be of type System.Enum");

            var enumValArray = Enum.GetValues(enumType);

            var enumValList = new List<TEnum>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((TEnum)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
    }
}
