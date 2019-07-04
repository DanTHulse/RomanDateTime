using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
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
