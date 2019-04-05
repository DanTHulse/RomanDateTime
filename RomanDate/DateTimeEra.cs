using System;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate
{
    public struct DateTimeEra
    {
        public DateTime DateTime { get; set; }
        public Eras Era { get; set; }

        public DateTimeEra(DateTime dateTime)
        {
            DateTime = dateTime;
            Era = Eras.AD;
        }

        public DateTimeEra(DateTime dateTime, Eras era)
        {
            DateTime = dateTime;
            Era = era;
        }

        public DateTimeEra AddHours(int hours)
        {
            var newDate = DateTime.AddHours(hours);
            return new DateTimeEra();
        }

        public DateTimeEra TryAddDays(int days)
        {
            if (Era == Eras.AD)
            {
                return AddDaysAD(days);
            }
            else
            {
                return AddDaysBC(days);
            }
        }

        private DateTimeEra AddDaysAD(int days)
        {
            var minAD = DateTime.MinValue;
            var startBC = new DateTime(2000, 12, 31);
            var daysBetween = (DateTime - minAD).Days;

            if (days <= 0) // if subtracting days
            {
                if (daysBetween <= Math.Abs(days)) // if days left before BC is less than days subtracting
                {
                    var daysToSubtract = Math.Abs(days) - daysBetween;
                    var newDate2 = startBC.AddDays(daysToSubtract == 0 ? 0 : -(daysToSubtract - 1));
                    var years = (startBC.Year - newDate2.Year) + 1;

                    var eraDate = new DateTime(years, newDate2.Month, newDate2.Day, newDate2.Hour, newDate2.Minute, newDate2.Second, newDate2.Millisecond);
                    return new DateTimeEra(eraDate, Eras.BC); // return date in BC era
                }
            }

            var newDate = DateTime.AddDays(days);

            return new DateTimeEra(newDate, Eras.AD); // Add days to existing DateTime in AD
        }

        private DateTimeEra AddDaysBC(int days)
        {
            var maxBC = new DateTime(1, 12, 31);
            var startBC = new DateTime(2000, 12, 31);
            var daysBetween = (maxBC - DateTime).Days;

            if (days >= 0) // if adding days
            {
                if (daysBetween <= Math.Abs(days)) // if days left before AD is less than days adding
                {
                    var daysToAdd = Math.Abs(days) - daysBetween;
                    var newDate2 = DateTime.MinValue.AddDays(daysToAdd == 0 ? 0 : (daysToAdd - 1));

                    return new DateTimeEra(newDate2, Eras.AD);
                }

                var exDate = startBC.AddDays(days);
                var years = (startBC.Year - exDate.Year);
                var newDate = DateTime.AddDays(days);

                return new DateTimeEra(newDate, Eras.BC);
            }
            else // else subtracting days
            {
                var exDate = startBC.AddDays(days);
                var years = (startBC.Year - exDate.Year);
                var newDate = DateTime.AddYears(years).AddDays(days);

                return new DateTimeEra(newDate, Eras.BC);
            }

            //return new DateTimeEra(DateTime.AddDays(days), Era);
        }

        public DateTimeEra AddWeeks(int weeks)
        {
            return new DateTimeEra();
        }

        public DateTimeEra AddMonths(int months)
        {
            return new DateTimeEra();
        }

        public DateTimeEra AddYears(int years)
        {
            return new DateTimeEra();
        }
    }
}