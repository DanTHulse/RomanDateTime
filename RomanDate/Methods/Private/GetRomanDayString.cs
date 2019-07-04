using System.Text;

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

            sb.Append($"{(shorten ? dPrefix.Short : dPrefix.Long)} ");

            if (this.DaysUntilSetDay > 2)
                sb.Append($"{this.DaysUntilSetDay.ToRomanNumerals()} ");

            if (this.DaysUntilSetDay == 0)
                sb.Append($"{(shorten ? sDay.Short : sDay.Ablative)} ");
            else
                sb.Append($"{(shorten ? sDay.Short : sDay.Accusative)} ");

            if (this.DaysUntilSetDay > 2)
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Accusative)}");
            else
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Ablative)}");

            return sb.ToString().TrimStart();
        }
    }
}