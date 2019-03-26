using RomanDate.Enums;

namespace RomanDate.Definitions
{
    /// <summary>
    /// Represents a set day used to build the Roman representation of a day
    /// </summary>
    public struct RomanSetDays
    {
        /// <summary>
        /// Gets an enum representation of the set day.
        /// </summary>
        public SetDays SetDay { get; }

        /// <summary>
        /// Gets the short form name of the set day.
        /// </summary>
        internal string Short { get; }
        /// <summary>
        /// Gets the accusative form name of the set day.
        /// </summary>
        internal string Accusative { get; }
        /// <summary>
        /// Gets the ablative form name of the set day.
        /// </summary>
        internal string Ablative { get; }

        /// <summary>
        /// Gets am instance of <see cref="RomanSetDays"/> that represents the Kalendae
        /// </summary>
        /// <remarks>The Kalendae is the first sacred day of the month and always falls on the first</remarks>
        public static RomanSetDays Kalendae => new RomanSetDays(SetDays.Kalendae, "Kalendas", "Kalendis", "Kal.");
        /// <summary>
        /// Gets am instance of <see cref="RomanSetDays"/> that represents the Nonae
        /// </summary>
        /// <remarks>The Nonae is the second sacred day of the month and always falls 9 days (as a Roman would count so 8) 
        /// before that months Idus (usually on the 5th but sometimes the 7th)</remarks>
        public static RomanSetDays Nonae => new RomanSetDays(SetDays.Nonae, "Nonas", "Nonis", "Non.");
        /// <summary>
        /// Gets am instance of <see cref="RomanSetDays"/> that represents the Idus
        /// </summary>
        /// <remarks>The Idus is the final sacred day of the month and traditianlly would fall on the full moon, but later 
        /// mostly on the 13th but sometimes the 15th</remarks>
        public static RomanSetDays Idus => new RomanSetDays(SetDays.Idus, "Idus", "Idibus", "Id.");

        private RomanSetDays(SetDays setDay, string accV, string ablV, string shortV)
        {
            SetDay = setDay;
            Accusative = accV;
            Ablative = ablV;
            Short = shortV;
        }
    }
}
