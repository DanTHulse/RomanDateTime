using RomanDateTime.Enums;
using RomanDateTime.Helpers;

namespace RomanDate.Definitions
{
    public struct RomanMonths
    {
        public Months Month { get; }

        public int Kalendae { get; }

        public int Nonae { get; }

        public int Idus { get; }

        public int End { get; }

        internal double HourLengthDay { get; }

        internal double HourLengthNight => (2 - this.HourLengthDay);

        internal string Short => $"{this.Accusative.Left(3)}.";

        internal string Accusative { get; }

        internal string Ablative { get; }

        internal int InterKalendae => this.Nonae - this.Kalendae - 1;

        internal int InterNonae => this.Idus - this.Nonae - 1;

        internal int InterIdus => this.End - this.Idus;

        public static RomanMonths Ianuarias => new(Months.Ianuarius, "Ianuarias", "Ianuariis", 0.82);

        public static RomanMonths Februarius => new(Months.Februarius, "Februarias", "Februariis", 28, 0.91);

        public static RomanMonths Martius => new(Months.Martius, "Martias", "Martiis", 7, 15, 1.0);

        public static RomanMonths Aprilis => new(Months.Aprilis, "Apriles", "Aprilibus", 30, 1.09);

        public static RomanMonths Maius => new(Months.Maius, "Maias", "Maiis", 7, 15, 1.18);

        public static RomanMonths Iunius => new(Months.Iunius, "Iunias", "Iuniis", 30, 1.27);

        public static RomanMonths Iulius => new(Months.Iulius, "Iulias", "Iuliis", 7, 15, 1.18);

        public static RomanMonths Augustus => new(Months.Augustus, "Augustas", "Augustis", 1.09);

        public static RomanMonths September => new(Months.September, "Septembres", "Septembribus", 30, 1.0);

        public static RomanMonths October => new(Months.October, "Octobres", "Octobrius", 7, 15, 0.91);

        public static RomanMonths November => new(Months.November, "Novembres", "Novembribus", 30, 0.82);

        public static RomanMonths December => new(Months.December, "Decembres", "Decembribus", 0.73);

        private RomanMonths(Months month, string accV, string ablV, double hourLength)
            : this(month, accV, ablV, 5, 13, 31, hourLength)
        {
        }

        private RomanMonths(Months month, string accV, string ablV, int end, double hourLength)
            : this(month, accV, ablV, 5, 13, end, hourLength)
        {
        }

        private RomanMonths(Months month, string accV, string ablV, int non, int id, double hourLength)
            : this(month, accV, ablV, non, id, 31, hourLength)
        {
        }

        private RomanMonths(Months month, string accV, string ablV, int non, int id, int end, double hourLength)
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

        public static RomanMonths GetRomanMonth(int month) => GetRomanMonth((Months)month);

        public static RomanMonths GetRomanMonth(Months month)
        {
            return month switch
            {
                Months.Ianuarius => Ianuarias,
                Months.Februarius => Februarius,
                Months.Martius => Martius,
                Months.Aprilis => Aprilis,
                Months.Maius => Maius,
                Months.Iunius => Iunius,
                Months.Iulius => Iulius,
                Months.Augustus => Augustus,
                Months.September => September,
                Months.October => October,
                Months.November => November,
                Months.December => December,
                _ => new RomanMonths(),
            };
        }

        public int GetSetDay(PrincipalDays setDay)
        {
            return setDay switch
            {
                PrincipalDays.Kalendae => this.Kalendae,
                PrincipalDays.Nonae => this.Nonae,
                PrincipalDays.Idus => this.Idus,
                _ => 1,
            };
        }
    }
}
