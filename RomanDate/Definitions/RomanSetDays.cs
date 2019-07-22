using System;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    /// <summary>
    /// Represents a set day used to build the Roman representation of a day
    /// </summary>
    public struct RomanSetDays : IComparable<RomanSetDays>
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

        private RomanSetDays(SetDays setDay, string accV, string ablV, string shortV)
        {
            this.SetDay = setDay;
            this.Accusative = accV;
            this.Ablative = ablV;
            this.Short = shortV;
        }

        /// <summary>
        /// Gets the full instance of the Roman set day by its enum value.
        /// </summary>
        /// <param name="month">The enum representation of the Roman set day.</param>
        /// <returns>An instance of <see cref="RomanSetDays"/> representing the enum value</returns>
        public static RomanSetDays GetRomanSetDay(SetDays setDay)
        {
            return setDay switch
            {
                SetDays.Kalendae => new RomanSetDays(SetDays.Kalendae, "Kalendas", "Kalendis", "Kal."),
                SetDays.Nonae => new RomanSetDays(SetDays.Nonae, "Nonas", "Nonis", "Non."),
                SetDays.Idus => new RomanSetDays(SetDays.Idus, "Idus", "Idibus", "Id."),
                _ => throw new InvalidOperationException("Not a valid value for RomanSetDays")
            };
        }

        public int CompareTo(RomanSetDays other) => ((IComparable)(int)this.SetDay).CompareTo((int)other.SetDay);
    }
}
