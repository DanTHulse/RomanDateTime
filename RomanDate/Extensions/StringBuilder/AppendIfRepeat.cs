using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
        internal static StringBuilder AppendIfRepeat(this StringBuilder sb, object s, bool condition, int repeat)
        {
            if (condition)
            {
                for (var x = 0; x < repeat; x++)
                {
                    _ = sb.Append(s.ToString());
                }
            }

            return sb;
        }
    }
}
