using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
        internal static void AppendRepeat(this StringBuilder sb, object s, int repeat)
        {
            for (var x = 0; x < repeat; x++)
            {
                sb.Append(s.ToString());
            }
        }
    }
}
