namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetAucYear()
        {
            var auc = 753;
            var year = (auc += this.DateTimeData.Year);
            return year <= 0 ? "" : year.ToRomanNumerals();
        }
    }
}