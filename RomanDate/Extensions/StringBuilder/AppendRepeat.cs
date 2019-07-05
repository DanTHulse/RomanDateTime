using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
        internal static StringBuilder AppendRepeat(this StringBuilder sb, object s, int repeat)
        {
            for (var x = 0; x < repeat; x++)
            {
                _ = sb.Append(s.ToString());
            }

            return sb;
        }
    }
}
