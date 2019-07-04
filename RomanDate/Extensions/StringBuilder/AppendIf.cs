using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
        internal static void AppendIf(this StringBuilder sb, object s, bool condition)
        {
            if (condition)
            {
                sb.Append(s.ToString());
            }
        }
    }
}
