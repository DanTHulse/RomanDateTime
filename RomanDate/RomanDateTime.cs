using System;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;
using RomanDate.Helpers.RomanNumerals;

namespace RomanDate
{
    /// <summary>
    /// Represents an instant in time, formatted with and using the rules of the Roman calendar post Julian reforms
    /// </summary>
    public partial struct RomanDateTime : IComparable<RomanDateTime>, IEquatable<RomanDateTime>
    {
        /// <summary>
        /// Gets the year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        public string Year => this.DateTimeData.YearOfEra.ToRomanNumerals();

        /// <summary>
        /// Gets the AUC year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        /// <remarks>AUC refers to from the founding of the City of Rome (753 BC)</remarks>
        public string AucYear => (this.DateTimeData.Year + 753).ToRomanNumerals();

        /// <summary>
        /// Gets the Consular year component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>The Romans named their years by who was in office as Consul (or other high ranking office)</remarks>
        public string ConsularYear => this.Magistrates.ParseConsularYear();

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
        /// Gets the "actual" month of the Roman date represented by this insteance
        /// </summary>
        /// <remarks>The Romans spoke about dates differently to us and used a reference month to describe what day it is,
        /// see the "Month" property for more info. This property exists to make it easier to tell where a certain date falls in
        /// our calender system</remarks>
        public Months ActualMonth => this.CalendarMonth.Month;

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
        /// Gets only the Date part of the Roman date represented by this instance.
        /// </summary>
        public string Date => $"{this.Day} {this.Year}";

        /// <summary>
        /// Gets only the Date (with AUC year) part of the Roman date represented by this instance.
        /// </summary>
        public string AucDate => $"{this.Day} {this.AucYear}";

        /// <summary>
        /// Consular and Magistrate date of the Roman date represented by this instance.
        /// </summary>
        public RomanMagistrates Magistrates => RomanMagistrates.Get((this.DateTimeData.Year + 753));

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

        internal RomanMonths CalendarMonth => (RomanMonths.GetRomanMonth((Months)this.DateTimeData.Month));

        internal RomanMonths ReferenceMonth => (this.DateTimeData.Day != 1 && this.RomanSetDay.SetDay == SetDays.Kalendae)
                                            ? RomanMonths.GetRomanMonth(this.CalendarMonth.Month.Next())
                                            : this.CalendarMonth;

        internal RomanSetDays RomanSetDay => this.GetSetDay();

        internal RomanDayPrefixes RomanDayPrefix => this.GetDayPrefix();

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
            this.DateTimeData = LocalDateTimeEx.ToLocalDateTime(year, 1, 1, 0, era);
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
            this.DateTimeData = LocalDateTimeEx.ToLocalDateTime(year, month, 1, 0, era);
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
            this.DateTimeData = LocalDateTimeEx.ToLocalDateTime(year, month, day, 0, era);
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
            this.DateTimeData = LocalDateTimeEx.ToLocalDateTime(year, month, day, hour, era);
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

        #region Deconstructors

        public void Deconstruct(out int year, out int month, out int day)
        {
            year = this.DateTimeData.Year;
            month = this.DateTimeData.Month;
            day = this.DateTimeData.Day;
        }

        public void Deconstruct(out int year, out int month, out int day, out int hour)
        {
            year = this.DateTimeData.Year;
            month = this.DateTimeData.Month;
            day = this.DateTimeData.Day;
            hour = this.DateTimeData.Hour;
        }

        #endregion

        public int CompareTo(RomanDateTime obj) => ((IComparable)this.DateTimeData).CompareTo(obj.DateTimeData);
        public bool Equals(RomanDateTime obj) => $"{this.Era} {this.Date} {this.Time}" == $"{obj.Era} {obj.Date} {obj.Time}";

        public static explicit operator DateTime(RomanDateTime rdt) => rdt.ToDateTime().DateTime;
        public static explicit operator LocalDateTime(RomanDateTime rdt) => rdt.DateTimeData;
        public static explicit operator RomanDateTime(DateTime dt) => new RomanDateTime(dt);
        public static explicit operator RomanDateTime(LocalDateTime ldt) => new RomanDateTime(ldt);
    }
}