using System;
using System.ComponentModel;

namespace RomanDate.Extensions
{
    internal static partial class EnumEx
    {
        internal static string GetDescription<T>(this T source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Enum value provided is null");

            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return source.ToString();
        }
    }
}