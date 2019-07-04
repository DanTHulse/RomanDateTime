namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetRomanYear() => this.DateTimeData.YearOfEra.ToRomanNumerals();
    }
}