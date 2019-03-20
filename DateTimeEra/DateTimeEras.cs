using System;
using DateTimeEra.Enums;

namespace DateTimeEra
{
    public struct DateTimeEras
    {
        public int Year => GetYear();
        public int Month => GetMonth();
        public int Day => GetDay();
        public int Hour => GetHour();
        public int Minute => GetMinute();
        public int Second => GetSecond();
        public int Millisecond => GetMillisecond();
        public Era Era => GetEra();

        private(int y, int m, int d, int h, int mn, int s, int mi, Era era) _temp;

        public DateTimeEras(int year, Era era = Era.AD)
        {
            _temp = (year, 1, 1, 0, 0, 0, 0, era);
        }

        public DateTimeEras(int year, int month, Era era = Era.AD)
        {
            _temp = (year, month, 1, 0, 0, 0, 0, era);
        }

        public DateTimeEras(int year, int month, int day, Era era = Era.AD)
        {
            _temp = (year, month, day, 0, 0, 0, 0, era);
        }

        public DateTimeEras(int year, int month, int day, int hour, int minute, int seconds, Era era = Era.AD)
        {
            _temp = (year, month, day, hour, minute, seconds, 0, era);
        }

        public DateTimeEras(int year, int month, int day, int hour, int minute, int seconds, int milliseconds, Era era = Era.AD)
        {
            _temp = (year, month, day, hour, minute, seconds, milliseconds, era);
        }

        #region Setups

        private int GetYear()
        {
            if (_temp.y > 9999 || _temp.y < -9999)
                throw new ArgumentOutOfRangeException(null, "Year must be between -9999 and 9999");
            if (_temp.y == 0)
                throw new ArgumentOutOfRangeException(null, "There is no Year zero");
            return _temp.y;
        }

        private bool GetIsLeapYear(int year)
        {
            return (DateTime.DaysInMonth(year, 2) == 29);
        }

        private int GetMonth()
        {
            if (_temp.m > 12 || _temp.y < 1)
                throw new ArgumentOutOfRangeException(null, "Invalid month provided");
            return _temp.m;
        }

        private int GetDay()
        {
            int[] days;
            if (GetIsLeapYear(Year))
                days = DateTimeErasConstants.DaysInMonth366;
            else
                days = DateTimeErasConstants.DaysInMonth365;

            if (_temp.d > days[Month] || _temp.d < 0)
                throw new ArgumentOutOfRangeException(null, "Invalid day provided");
            return _temp.d;
        }

        private int GetHour()
        {
            if (_temp.h > 23 || _temp.h < 0)
                throw new ArgumentOutOfRangeException(null, "Invalid hour provided");
            return _temp.h;
        }

        private int GetMinute()
        {
            if (_temp.mn > 59 || _temp.mn < 0)
                throw new ArgumentOutOfRangeException(null, "Invalid minutes provided");
            return _temp.mn;
        }

        private int GetSecond()
        {
            if (_temp.s > 59 || _temp.s < 0)
                throw new ArgumentOutOfRangeException(null, "Invalid seconds provided");
            return _temp.s;
        }

        private int GetMillisecond()
        {
            if (_temp.mi > 99 || _temp.mi < 0)
                throw new ArgumentOutOfRangeException(null, "Invalid milliseconds provided");
            return _temp.mi;
        }

        private Era GetEra()
        {
            return _temp.era;
        }

        #endregion
    }
}