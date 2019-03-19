using System.Text;

namespace RomanDate.Helpers
{
    public static class StringBuilderHelpers
    {
        public static void AppendIf(this StringBuilder sb, object s, bool condition)
        {
            if (condition)
            {
                sb.Append(s.ToString());
            }
        }

        public static void AppendRepeat(this StringBuilder sb, object s, int repeat)
        {
            for (int x = 0; x < repeat; x++)
            {
                sb.Append(s.ToString());
            }
        }

        public static void AppendIfRepeat(this StringBuilder sb, object s, bool condition, int repeat)
        {
            if (condition)
            {
                for (int x = 0; x < repeat; x++)
                {
                    sb.Append(s.ToString());
                }
            }
        }
    }
}
