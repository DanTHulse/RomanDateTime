using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Definitions
{
    /// <summary>
    /// Represents a month used in the Roman calendar
    /// </summary>
    public struct RomanMonths
    {
        /// <summary>
        /// Gets an enum representation of the month.
        /// </summary>
        public Months Month { get; }

        /// <summary>
        /// Gets the day of the month the Kalendae falls on.
        /// </summary>
        public int Kalendae { get; }

        /// <summary>
        /// Gets the day of the month the Nonae falls on.
        /// </summary>
        public int Nonae { get; }

        /// <summary>
        /// Gets the day of the month the Idus falls on.
        /// </summary>
        public int Idus { get; }

        /// <summary>
        /// Gets the last day of the month.
        /// </summary>
        public int End { get; }

        /// <summary>
        /// Gets the hour length during the day for the month.
        /// </summary>
        internal double HourLengthDay { get; }

        /// <summary>
        /// Gets the hour length during the night for the month.
        /// </summary>
        internal double HourLengthNight => (2 - this.HourLengthDay);

        /// <summary>
        /// Gets the short form name of the set day.
        /// </summary>
        internal string Short => $"{this.Accusative.Left(3)}.";

        /// <summary>
        /// Gets the accusative form name of the set day.
        /// </summary>
        internal string Accusative { get; }

        /// <summary>
        /// Gets the ablative form name of the set day.
        /// </summary>
        internal string Ablative { get; }

        /// <summary>
        /// Gets the number of days between the months Kal. and Non.
        /// </summary>
        internal int InterKalendae => this.Nonae - this.Kalendae - 1;

        /// <summary>
        /// Gets the number of days between the months Non. and Id.
        /// </summary>
        internal int InterNonae => this.Idus - this.Nonae - 1;

        /// <summary>
        /// Gets the number of days between the months Id. and next months Kal.
        /// </summary>
        internal int InterIdus => this.End - this.Idus;

        // private RomanMonths(Months month, string accV, string ablV, int end, double hourLength)
        // {
        //     this.Month = month;
        //     this.Accusative = accV;
        //     this.Ablative = ablV;
        //     this.Kalendae = 1;
        //     this.Nonae = 5;
        //     this.Idus = 13;
        //     this.End = end;
        //     this.HourLengthDay = hourLength;
        // }

        private RomanMonths(Months month, string accV, string ablV, int end, int non, int id, double hourLength)
        {
            this.Month = month;
            this.Accusative = accV;
            this.Ablative = ablV;
            this.Kalendae = 1;
            this.Nonae = non;
            this.Idus = id;
            this.End = end;
            this.HourLengthDay = hourLength;
        }

        /// <summary>
        /// Gets the full instance of the Roman month from the integer value.
        /// </summary>
        /// <param name="month">The integer representation of the Roman month.</param>
        /// <returns>An instance of <see cref="RomanMonths"/> representing the integer value</returns>
        public static RomanMonths GetRomanMonth(int month) => GetRomanMonth((Months)month);

        /// <summary>
        /// Gets the full instance of the Roman month by its enum value.
        /// </summary>
        /// <param name="month">The enum representation of the Roman month.</param>
        /// <returns>An instance of <see cref="RomanMonths"/> representing the enum value</returns>
        public static RomanMonths GetRomanMonth(Months month)
        {
            return month switch
            {
                Months.Ianuarius  => new RomanMonths(month, "Ianuarias", "Ianuariis", 31, 5, 13, 0.82),
                Months.Februarius => new RomanMonths(month, "Februarias", "Februariis", 28, 5, 13, 0.91),
                Months.Martius    => new RomanMonths(month, "Martias", "Martiis", 31, 7, 15, 1.0),
                Months.Aprilis    => new RomanMonths(month, "Apriles", "Aprilibus", 30, 5, 13, 1.09),
                Months.Maius      => new RomanMonths(month, "Maias", "Maiis", 31, 7, 15, 1.18),
                Months.Iunius     => new RomanMonths(month, "Iunias", "Iuniis", 30, 5, 13, 1.27),
                Months.Iulius     => new RomanMonths(month, "Iulias", "Iuliis", 31, 7, 15, 1.18),
                Months.Augustus   => new RomanMonths(month, "Augustas", "Augustis", 31, 5, 13, 1.09),
                Months.September  => new RomanMonths(month, "Septembres", "Septembribus", 30, 5, 13, 1.0),
                Months.October    => new RomanMonths(month, "Octobres", "Octobrius", 31, 7, 15, 0.91),
                Months.November   => new RomanMonths(month, "Novembres", "Novembribus", 30, 5, 13,  0.82),
                Months.December   => new RomanMonths(month, "Decembres", "Decembribus", 31, 5, 13, 0.73),
                _                 => new RomanMonths()
            };
        }
    }
}
