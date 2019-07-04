using System.Linq;
using System.Text;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        internal static string ParseConsularYear(this ConsularDate data)
        {
            if (data != null)
            {
                var magistrates = new ElectedMagistrates(data);

                if (!string.IsNullOrEmpty(data.Override))
                    return data.Override;

                var sb = new StringBuilder();
                sb.Append($"Year of the {data.YearOf.GetDescription()} of ");

                if (data.YearOf == YearOf.Dictatorship)
                {
                    sb.Append(magistrates.Dictator.ShortName);
                }
                else if (data.YearOf == YearOf.Tribunship)
                {
                    sb.Append($"{string.Join(", ", magistrates.Tribuni.Take(magistrates.Tribuni.Count() - 1).Select(s => s.ShortName))}, and {magistrates.Tribuni.Last().ShortName}");
                }
                else if (data.YearOf == YearOf.Consulship)
                {
                    sb.Append(magistrates.ConsulPrior.ShortName);

                    if (magistrates.ConsulPosterior != null)
                        sb.Append($" and {magistrates.ConsulPosterior.ShortName}");
                    else
                        sb.Append(" without colleague");
                }

                return sb.ToString();
            }

            return "";
        }
    }
}