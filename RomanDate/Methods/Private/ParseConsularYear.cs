using System.Linq;
using System.Text;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string ParseConsularYear(ConsularDate data)
        {
            if (data != null)
            {
                var magistrates = new ElectedMagistrates(data);

                if (!string.IsNullOrEmpty(data.Override))
                    return data.Override;

                var sb = new StringBuilder();
                _ = sb.Append($"Year of the {data.YearOf.GetDescription()} of ");

                if (data.YearOf == YearOf.Dictatorship)
                {
                    _ = sb.Append(magistrates.Dictator.ShortName);
                }
                else if (data.YearOf == YearOf.Tribunship)
                {
                    _ = sb.Append($"{string.Join(", ", magistrates.Tribuni.Take(magistrates.Tribuni.Count() - 1).Select(s => s.ShortName))}, and {magistrates.Tribuni.Last().ShortName}");
                }
                else if (data.YearOf == YearOf.Consulship)
                {
                    _ = sb.Append(magistrates.ConsulPrior.ShortName);

                    if (magistrates.ConsulPosterior != null)
                        _ = sb.Append($" and {magistrates.ConsulPosterior.ShortName}");
                    else
                        _ = sb.Append(" without colleague");
                }

                return sb.ToString();
            }

            return "";
        }
    }
}