using System.Text;
using RomanDate.Helpers.RomanNumerals;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetRomanDayString(bool shorten = false)
        {
            var sb = new StringBuilder();
            var rMonth = this.ReferenceMonth;
            var sDay = this.RomanSetDay;
            var dPrefix = this.RomanDayPrefix;

            _ = sb.Append($"{(shorten ? dPrefix.Short : dPrefix.Long)} ");

            if (this.DaysUntilSetDay > 2)
                _ = sb.Append($"{this.DaysUntilSetDay.ToRomanNumerals()} ");

            if (this.DaysUntilSetDay == 0)
                _ = sb.Append($"{(shorten ? sDay.Short : sDay.Ablative)} ");
            else
                _ = sb.Append($"{(shorten ? sDay.Short : sDay.Accusative)} ");

            if (this.DaysUntilSetDay > 2)
                _ = sb.Append($"{(shorten ? rMonth.Short : rMonth.Accusative)}");
            else
                _ = sb.Append($"{(shorten ? rMonth.Short : rMonth.Ablative)}");

            return sb.ToString().TrimStart();
        }
    }
}