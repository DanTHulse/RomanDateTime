﻿using System.Text;

namespace RomanDate.Extensions
{
    internal static class StringBuilderEx
    {
        internal static void AppendIf(this StringBuilder sb, object s, bool condition)
        {
            if (condition)
            {
                sb.Append(s.ToString());
            }
        }

        internal static void AppendRepeat(this StringBuilder sb, object s, int repeat)
        {
            for (var x = 0; x < repeat; x++)
            {
                sb.Append(s.ToString());
            }
        }

        internal static void AppendIfRepeat(this StringBuilder sb, object s, bool condition, int repeat)
        {
            if (condition)
            {
                for (var x = 0; x < repeat; x++)
                {
                    sb.Append(s.ToString());
                }
            }
        }
    }
}