using System.Text;

namespace RomanDate.Extensions
{
    internal static partial class StringBuilderEx
    {
        internal static StringBuilder AppendIf(this StringBuilder sb, object s, bool condition)
        {
            if (condition)
            {
                return sb.Append(s.ToString());
            }

            return sb;
        }
    }
}
