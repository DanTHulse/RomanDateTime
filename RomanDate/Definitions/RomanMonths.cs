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

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Ianuarias (January)
        /// </summary>
        public static RomanMonths Ianuarias => new RomanMonths(Months.Ianuarius, "Ianuarias", "Ianuariis", 0.82);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Februarius (February)
        /// </summary>
        public static RomanMonths Februarius => new RomanMonths(Months.Februarius, "Februarias", "Februariis", 28, 0.91);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Martius (March)
        /// </summary>
        public static RomanMonths Martius => new RomanMonths(Months.Martius, "Martias", "Martiis", 7, 15, 1.0);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Aprilis (April)
        /// </summary>
        public static RomanMonths Aprilis => new RomanMonths(Months.Aprilis, "Apriles", "Aprilibus", 30, 1.09);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Maius (May)
        /// </summary>
        public static RomanMonths Maius => new RomanMonths(Months.Maius, "Maias", "Maiis", 7, 15, 1.18);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Iunius (June)
        /// </summary>
        public static RomanMonths Iunius => new RomanMonths(Months.Iunius, "Iunias", "Iuniis", 30, 1.27);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Iulius (July)
        /// </summary>
        public static RomanMonths Iulius => new RomanMonths(Months.Iulius, "Iulias", "Iuliis", 7, 15, 1.18);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents Augustus (August)
        /// </summary>
        public static RomanMonths Augustus => new RomanMonths(Months.Augustus, "Augustas", "Augustis", 1.09);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents September
        /// </summary>
        public static RomanMonths September => new RomanMonths(Months.September, "Septembres", "Septembribus", 30, 1.0);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents October
        /// </summary>
        public static RomanMonths October => new RomanMonths(Months.October, "Octobres", "Octobrius", 7, 15, 0.91);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents November
        /// </summary>
        public static RomanMonths November => new RomanMonths(Months.November, "Novembres", "Novembribus", 30, 0.82);

        /// <summary>
        /// Gets am instance of <see cref="RomanMonths"/> that represents December
        /// </summary>
        public static RomanMonths December => new RomanMonths(Months.December, "Decembres", "Decembribus", 0.73);

        private RomanMonths(Months month, string accV, string ablV, double hourLength)
        {
            this.Month = month;
            this.Accusative = accV;
            this.Ablative = ablV;
            this.Kalendae = 1;
            this.Nonae = 5;
            this.Idus = 13;
            this.End = 31;
            this.HourLengthDay = hourLength;
        }

        private RomanMonths(Months month, string accV, string ablV, int end, double hourLength)
        {
            this.Month = month;
            this.Accusative = accV;
            this.Ablative = ablV;
            this.Kalendae = 1;
            this.Nonae = 5;
            this.Idus = 13;
            this.End = end;
            this.HourLengthDay = hourLength;
        }

        private RomanMonths(Months month, string accV, string ablV, int non, int id, double hourLength)
        {
            this.Month = month;
            this.Accusative = accV;
            this.Ablative = ablV;
            this.Kalendae = 1;
            this.Nonae = non;
            this.Idus = id;
            this.End = 31;
            this.HourLengthDay = hourLength;
        }

        /// <summary>
        /// Gets the full instance of the Roman month from the integer value.
        /// </summary>
        /// <param name="month">The integer representation of the Roman month.</param>
        /// <returns>An instance of <see cref="RomanMonths"/> representing the integer value</returns>
        public static RomanMonths GetRomanMonth(int month)
        {
            return GetRomanMonth((Months)month);
        }

        /// <summary>
        /// Gets the full instance of the Roman month by it's enum value.
        /// </summary>
        /// <param name="month">The enum representation of the Roman month.</param>
        /// <returns>An instance of <see cref="RomanMonths"/> representing the enum value</returns>
        public static RomanMonths GetRomanMonth(Months month)
        {
            switch (month)
            {
                case Months.Ianuarius:
                    return Ianuarias;
                case Months.Februarius:
                    return Februarius;
                case Months.Martius:
                    return Martius;
                case Months.Aprilis:
                    return Aprilis;
                case Months.Maius:
                    return Maius;
                case Months.Iunius:
                    return Iunius;
                case Months.Iulius:
                    return Iulius;
                case Months.Augustus:
                    return Augustus;
                case Months.September:
                    return September;
                case Months.October:
                    return October;
                case Months.November:
                    return November;
                case Months.December:
                    return December;
                default:
                    return new RomanMonths();
            }
        }

        /// <summary>
        /// Gets the day of the month the provided Set Day falls on for this instance.
        /// </summary>
        /// <param name="setDay">The set day enum value for the day required.</param>
        /// <returns>The day of the month the specified set day falls on for this instance</returns>
        public int GetSetDay(SetDays setDay)
        {
            switch (setDay)
            {
                case SetDays.Kalendae:
                    return this.Kalendae;
                case SetDays.Nonae:
                    return this.Nonae;
                case SetDays.Idus:
                    return this.Idus;
                default:
                    return 1;
            }
        }
    }
}
