using System;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate
{
    /// <summary>
    /// Represents an instant in time, formatted with and using the rules of the Roman calendar post Julian reforms
    /// </summary>
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Gets the year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        public string Year => this.GetRomanYear();

        /// <summary>
        /// Gets the AUC year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        /// <remarks>AUC refers to from the founding of the City of Rome (753 BC)</remarks>
        public string AucYear => this.GetAucYear();

        /// <summary>
        /// Gets the Consular year component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>The Romans named their years by who was in office as Consul (or other high ranking office)</remarks>
        public string ConsularYear => this.GetConsularYear();

        /// <summary>
        /// Gets the day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>A day in the Roman calendar takes the form of counting towards the next "set" day 
        /// using inclusing counting, so </remarks>
        public string Day => this.GetRomanDayString();

        /// <summary>
        /// Gets the Nundinal letter component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>Nundinal letters represent the day of the week.
        /// The Romans had an 8-day week (A-H) though every 2 years the days would shift to keep the calendar aligned 
        /// so 28th Feb might be an (A) but 1st Mar could be (D)</remarks>
        public NundinalLetters NundinalLetter => this.GetNundinalLetter();

        /// <summary>
        /// Gets the set day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>Set days are the three sacred days of the month in the Roman calendar:
        /// Kalendae, Nonae, Idus</remarks>
        public SetDays SetDay => this.RomanSetDay.SetDay;

        /// <summary>
        /// Gets the day prefix component of the Roman date represented by this instance.
        /// </summary>
        public DayPrefixes DayPrefix => this.RomanDayPrefix.Prefix;

        /// <summary>
        /// Gets the reference month component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>In the latter half of the month the Romans would start counting down to the Kalends of next month</remarks>
        public Months Month => this.ReferenceMonth.Month;

        /// <summary>
        /// Gets the time component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>The Romans would start counting from Hour 1 always from sunrise and have 12 hours until sunset 
        /// This means the length of the hour varies throughout the year, also night time was tracked by the passage of 
        /// the watches, or Vigia, which each for a quarter of the length of night time</remarks>
        public string Time => this.GetTime();

        /// <summary>
        /// Gets the hour component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>This is just another way to represent the time, with hours replacing the Vigila at night</remarks>
        public string Hour => this.GetTime(true);

        /// <summary>
        /// Gets the days until the next set day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>This is an integer representation of the number of days until the next sacred day of the month 
        /// that makes up the representation of the day</remarks>
        public int? DaysUntilSetDay => this._daysUntil == null ? this.GetDaysUntil() : this._daysUntil;

        /// <summary>
        /// Gets the era component of the Roman date represented by this instance.
        /// </summary>
        public Eras Era { get; set; }

        /// <summary>
        /// Gets the magistrates that should have been in office at this date (accurate to the year, not month)
        /// </summary>
        public ElectedMagistrates ElectedMagistrates => this.GetMagistrates();

        #region Private Fields

        private readonly int? _daysUntil;

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets a new instance of <see cref="RomanDateTime" /> that represents the current date and time.
        /// </summary>
        public static RomanDateTime Now => new RomanDateTime(DateTime.Now);

        /// <summary>
        /// Gets a new instance of <see cref="RomanDateTime" /> that represents the maximun value of <seealso cref="DateTime"/>.
        /// </summary>
        public static RomanDateTime MaxValue => new RomanDateTime(DateTime.MaxValue);

        /// <summary>
        /// Gets a new instance of <see cref="RomanDateTime" /> that represents the minimum value of <seealso cref="DateTime"/>.
        /// </summary>
        public static RomanDateTime MinValue => new RomanDateTime(DateTime.MinValue);

        /// <summary>
        /// Gets a new instance of <see cref="RomanDateTime" /> that represents the maximun value of <seealso cref="DateTime"/> in the BC era.
        /// </summary>
        public static RomanDateTime AbsoluteMinValue => new RomanDateTime(DateTime.MaxValue, Eras.BC);

        #endregion

        #region Internal Properties

        internal LocalDateTime DateTimeData { get; }

        internal RomanMonths CalendarMonth => this.GetCalendarMonth();

        internal RomanMonths ReferenceMonth => this.GetReferenceMonth();

        internal RomanSetDays RomanSetDay => this.GetSetDay();

        internal RomanDayPrefixes RomanDayPrefix => this.GetDayPrefix();

        internal ConsularDate ConsularData => this.GetConsularDate();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, Eras era = Eras.AD)
        {
            this._daysUntil = null;
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, 1, 1, 0, era);
            this.Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year and month.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="month">The month (1-12).</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, int month, Eras era = Eras.AD)
        {
            this._daysUntil = null;
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, 1, 0, era);
            this.Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year, month and day.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="month">The month (1-12).</param>
        /// <param name="day">The day of the month (1 to the total days in the month)</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, int month, int day, Eras era = Eras.AD)
        {
            this._daysUntil = null;
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, 0, era);
            this.Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year, month, day and hour.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="month">The month (1-12).</param>
        /// <param name="day">The day of the month (1 to the total days in the month)</param>
        /// <param name="hour">The hour in 24h format (0-23)</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, int month, int day, int hour, Eras era = Eras.AD)
        {
            this._daysUntil = null;
            this.DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, hour, era);
            this.Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the <seealso cref="DateTime"/> provided.
        /// </summary>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>        
        public RomanDateTime(DateTime date, Eras era = Eras.AD)
        {
            this._daysUntil = null;
            this.DateTimeData = date.ToLocalDateTime(era);
            this.Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the <seealso cref="LocalDateTime"/> provided.
        /// </summary>
        private RomanDateTime(LocalDateTime date)
        {
            this._daysUntil = null;
            this.DateTimeData = date;
            this.Era = date.Year > 0 ? Eras.AD : Eras.BC;
        }

        #endregion
    }
}