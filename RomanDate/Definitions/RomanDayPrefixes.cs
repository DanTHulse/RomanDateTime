using System;
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

        private RomanDayPrefixes(DayPrefixes prefix = DayPrefixes.None, string longV = "", string shortV = "")
        {
            this.Prefix = prefix;
            this.Long = longV;
            this.Short = shortV;
        }

        /// <summary>
        /// Gets the full instance of the Roman day prefix by its enum value.
        /// </summary>
        /// <param name="month">The enum representation of the Roman day prefix.</param>
        /// <returns>An instance of <see cref="RomanDayPrefixes"/> representing the enum value</returns>
        public static RomanDayPrefixes GetRomanDayPrefix(DayPrefixes prefix)
        {
            return prefix switch
            {
                DayPrefixes.AnteDiem => new RomanDayPrefixes(DayPrefixes.AnteDiem, "ante diem", "a.d."),
                DayPrefixes.AnteDiemBis => new RomanDayPrefixes(DayPrefixes.AnteDiemBis, "ante diem bis", "a.d. b."),
                DayPrefixes.Pridie => new RomanDayPrefixes(DayPrefixes.Pridie, "pridie", "pr."),
                DayPrefixes.None => new RomanDayPrefixes(),
                _ => throw new InvalidOperationException("Not a valid value for RomanDayPrefixes")
            };
        }
    }
}
