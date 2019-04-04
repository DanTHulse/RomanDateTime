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
            var minAD = DateTime.MinValue;
            var startBC = new DateTime(2000, 12, 31);
            var daysBetween = (DateTime - minAD).Days;

            if (Era == Eras.AD && days <= 0)
            {
                if (daysBetween <= Math.Abs(days))
                {
                    var daysToSubtract = Math.Abs(days) - daysBetween;
                    var newDate2 = startBC.AddDays(daysToSubtract == 0 ? 0 : -(daysToSubtract - 1));
                    var years = (startBC.Year - newDate2.Year) + 1;

                    var eraDate = new DateTime(years, newDate2.Month, newDate2.Day, newDate2.Hour, newDate2.Minute, newDate2.Second, newDate2.Millisecond);
                    return new DateTimeEra(eraDate, Eras.BC);
                }

                var newDate = DateTime.AddDays(days);

                return new DateTimeEra(newDate);
            }
            else if (Era == Eras.BC && days >= 0)
            {

            }

            return new DateTimeEra(DateTime.AddDays(days), Era);
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