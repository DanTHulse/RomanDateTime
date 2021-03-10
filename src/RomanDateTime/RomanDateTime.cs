using System;
using NodaTime;
using RomanDate.Definitions;
using RomanDateTime.Enums;
using RomanDateTime.Helpers;

namespace RomanDateTime
{
    public partial struct RomanDateTime
    {
        public string Year => "";

        public string AucYear => "";

        public Months Month => Months.Aprilis;

        public string Day => "";

        public NundinalLetters NundinalLetter => NundinalLetters.A;

        public PrincipalDays PrincipalDay => PrincipalDays.Idus;

        public DayPrefixes DayPrefix => DayPrefixes.AnteDiem;

        public string Time => "";

        public string Hour => "";

        public int? DaysUntilPrincipalDay => 0;

        public Eras Era { get; set; }

        #region Static Properties

        public static RomanDateTime Now => new(DateTime.Now);
        public static RomanDateTime MaxValue => new(DateTime.MaxValue);
        public static RomanDateTime MinValue => new(DateTime.MinValue);
        public static RomanDateTime AbsoluteMinValue => new(DateTime.MaxValue, Eras.BC);

        #endregion


        #region Internal Properties

        internal LocalDateTime DateTimeData { get; }

        internal RomanMonths CalendarMonth => this.GetCalendarMonth();

        internal RomanMonths ReferenceMonth => this.GetReferenceMonth();

        internal RomanSetDays RomanSetDay => this.GetSetDay();

        internal RomanDayPrefixes RomanDayPrefix => this.GetDayPrefix();

        #endregion

        #region Constructors

        public RomanDateTime(int year, Eras era = Eras.AD)
        {
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, 1, 1, 0, era);
            this.Era = era;
        }

        public RomanDateTime(int year, int month, Eras era = Eras.AD)
        {
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, 1, 0, era);
            this.Era = era;
        }

        public RomanDateTime(int year, int month, int day, Eras era = Eras.AD)
        {
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, 0, era);
            this.Era = era;
        }

        public RomanDateTime(int year, int month, int day, int hour, Eras era = Eras.AD)
        {
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, hour, era);
            this.Era = era;
        }

        public RomanDateTime(DateTime date, Eras era = Eras.AD)
        {
            this.DateTimeData = date.ToLocalDateTime(era);
            this.Era = era;
        }

        private RomanDateTime(LocalDateTime date)
        {
            this.DateTimeData = date;
            this.Era = date.Year > 0 ? Eras.AD : Eras.BC;
        }

        #endregion
    }
}
