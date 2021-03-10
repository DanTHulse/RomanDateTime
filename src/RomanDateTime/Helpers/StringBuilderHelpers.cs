using System.Text;

namespace RomanDateTime.Helpers
{
    internal static class StringBuilderHelpers
    {
        internal static void AppendIf(this StringBuilder sb, object s, bool condition)
        {
            if (condition)
            {
                _ = sb.Append(s.ToString());
            }
        }

        internal static void AppendRepeat(this StringBuilder sb, object s, int repeat)
        {
            for (var x = 0; x < repeat; x++)
            {
                _ = sb.Append(s.ToString());
            }
        }

        internal static void AppendIfRepeat(this StringBuilder sb, object s, bool condition, int repeat)
        {
            if (condition)
            {
                for (var x = 0; x < repeat; x++)
                {
                    _ = sb.Append(s.ToString());
                }
            }
        }
    }
}
