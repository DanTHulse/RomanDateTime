namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetRomanYear()
        {
            return this.DateTimeData.YearOfEra.ToRomanNumerals();
        }
    }
}