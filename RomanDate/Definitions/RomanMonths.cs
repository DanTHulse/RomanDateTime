using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate.Definitions
{
    public struct RomanMonths
    {
        public Months Month { get; }
        public string Short => $"{Accusative.Left(3)}.";
        public string Accusative { get; }
        public string Ablative { get; }
        public int Kalendae { get; }
        public int InterKalendae => Nonae - Kalendae - 1;
        public int Nonae { get; }
        public int InterNonae => Idus - Nonae - 1;
        public int Idus { get; }
        public int InterIdus => End - Idus;
        public int End { get; }

        public double HourLengthDay { get; }
        public double HourLengthNight => (2 - HourLengthDay);

        public static RomanMonths Ianuarias => new RomanMonths(Months.Ianuarius, "Ianuarias", "Ianuariis", 0.82);
        public static RomanMonths Februarius => new RomanMonths(Months.Februarius, "Februarias", "Februariis", 28, 0.91);
        public static RomanMonths Martius => new RomanMonths(Months.Martius, "Martias", "Martiis", 7, 15, 1.0);
        public static RomanMonths Aprilis => new RomanMonths(Months.Aprilis, "Apriles", "Aprilibus", 30, 1.09);
        public static RomanMonths Maius => new RomanMonths(Months.Maius, "Maias", "Maiis", 7, 15, 1.18);
        public static RomanMonths Iunius => new RomanMonths(Months.Iunius, "Iunias", "Iuniis", 30, 1.27);
        public static RomanMonths Iulius => new RomanMonths(Months.Iulius, "Iulias", "Iuliis", 7, 15, 1.18);
        public static RomanMonths Augustus => new RomanMonths(Months.Augustus, "Augustas", "Augustis", 1.09);
        public static RomanMonths September => new RomanMonths(Months.September, "Septembres", "Septembribus", 30, 1.0);
        public static RomanMonths October => new RomanMonths(Months.October, "Octobres", "Octobrius", 7, 15, 0.91);
        public static RomanMonths November => new RomanMonths(Months.November, "Novembres", "Novembribus", 30, 0.82);
        public static RomanMonths December => new RomanMonths(Months.December, "Decembres", "Decembribus", 0.73);

        public RomanMonths(Months month, string accV, string ablV, double hourLength)
        {
            Month = month;
            Accusative = accV;
            Ablative = ablV;
            Kalendae = 1;
            Nonae = 5;
            Idus = 13;
            End = 31;
            HourLengthDay = hourLength;
        }

        public RomanMonths(Months month, string accV, string ablV, int end, double hourLength)
        {
            Month = month;
            Accusative = accV;
            Ablative = ablV;
            Kalendae = 1;
            Nonae = 5;
            Idus = 13;
            End = end;
            HourLengthDay = hourLength;
        }

        public RomanMonths(Months month, string accV, string ablV, int non, int id, double hourLength)
        {
            Month = month;
            Accusative = accV;
            Ablative = ablV;
            Kalendae = 1;
            Nonae = non;
            Idus = id;
            End = 31;
            HourLengthDay = hourLength;
        }

        public static RomanMonths GetRomanMonth(Months month)
        {
            var monthVal = (Months)month;

            switch (monthVal)
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
    }
}
