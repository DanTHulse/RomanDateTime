namespace RomanDate.Helpers.RomanDate
{
    public static partial class RomanDateHelpers
    {
        /// <summary>
        /// Determines whether this instance is a nundinae (market day).
        /// </summary>
        /// <remarks>The Nundinae is the market day for the Romans, due to superstitions a nundinae cannot fall 
        /// on a Nonae or on the Kalends of Jan. As a result the letter used for the nundinae changes accordingly to avoid these clashes</remarks>
        /// <param name="date">The instance of <see cref="RomanDateTime"/> to check.</param>
        /// <returns><c>true</c> if the specified date is a nundinae (market day); otherwise, <c>false</c>.</returns>
        public static bool IsNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            return nundinae == date.NundinalLetter;
        }
    }
}