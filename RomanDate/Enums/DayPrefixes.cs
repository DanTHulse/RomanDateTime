namespace RomanDate.Enums
{
    /// <summary>
    /// Enum representing the different prefixes used when representing days in the Roman calendar
    /// </summary>
    public enum DayPrefixes
    {
        /// <summary>
        /// No prefix
        /// </summary>
        None = 0,

        /// <summary>
        /// Before the Day (i.e. "ante diem VI" == "sixth day before")
        /// </summary>
        AnteDiem = 1,

        /// <summary>
        /// Twice Before the Day, the leap day prefix (i.e. "ante diem bis VI" == "twice sixth day before" or "repeated sixth day")
        /// </summary>
        AnteDiemBis = 2,

        /// <summary>
        /// Eve of, or, Day Before (i.e. "pridie idus" == "day before the Ides" or "Eve of the Ides")
        /// </summary>
        Pridie = 3
    }
}
