using RomanDate.Enums;

namespace RomanDate.Definitions
{
    /// <summary>
    /// Represents a prefix used to build the Roman representation of a day
    /// </summary>
    public struct RomanDayPrefixes
    {
        /// <summary>
        /// Gets an enum representation of the prefix.
        /// </summary>
        public DayPrefixes Prefix { get; }

        /// <summary>
        /// Gets the long form name of the prefix.
        /// </summary>
        internal string Long { get; }

        /// <summary>
        /// Gets the short form name of the prefix.
        /// </summary>
        internal string Short { get; }

        /// <summary>
        /// Gets am instance of <see cref="RomanDayPrefixes"/> that represents Ante Diem
        /// </summary>
        /// <remarks>Ante Diem roughly means, "# of days before" so "ante diem IV" = "4 days before"</remarks>
        public static RomanDayPrefixes AnteDiem => new RomanDayPrefixes(DayPrefixes.AnteDiem, "ante diem", "a.d.");

        /// <summary>
        /// Gets am instance of <see cref="RomanDayPrefixes"/> that represents Ante Diem Bis
        /// </summary>
        /// <remarks>Ante Diem Bis roughly means, "# of days before twice" and was used to represent the leap day 
        /// so the only time it's used is "ante diem bis VI Mar" = "6 days before Mar twice" followed by 
        /// "ante diem VI Mar" = "6 days before Mar", this was to prevent issues with the numbering of other days in the month</remarks>
        public static RomanDayPrefixes AnteDiemBis => new RomanDayPrefixes(DayPrefixes.AnteDiemBis, "ante diem bis", "a.d. b.");

        /// <summary>
        /// Gets am instance of <see cref="RomanDayPrefixes"/> that represents Pridie
        /// </summary>
        /// <remarks>Pridie roughly means, "the day before" or "the eve of" so "pridie Kal Mar" = "the day before the Kal of Mar"</remarks>
        public static RomanDayPrefixes Pridie => new RomanDayPrefixes(DayPrefixes.Pridie, "pridie", "pr.");

        private RomanDayPrefixes(DayPrefixes prefix = DayPrefixes.None, string longV = "", string shortV = "")
        {
            this.Prefix = prefix;
            this.Long = longV;
            this.Short = shortV;
        }
    }
}
