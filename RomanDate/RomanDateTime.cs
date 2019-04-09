using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;
using System;
using System.Text;

namespace RomanDate
{
    /// <summary>
    /// Represents an instant in time, formatted with and using the rules of the Roman calendar post Julian reforms
    /// </summary>
    public struct RomanDateTime
    {
        /// <summary>
        /// Gets the year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        public string Year => GetRomanYear();
        /// <summary>
        /// Gets the AUC year component of the Roman date represented by this instance in Roman Numerals.
        /// </summary>
        /// <remarks>AUC refers to from the founding of the City of Rome (753 BC)</remarks>
        public string AucYear => GetAucYear();
        /// <summary>
        /// Gets the day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>A day in the Roman calendar takes the form of counting towards the next "set" day 
        /// using inclusing counting, so </remarks>
        public string Day => GetRomanDayString();
        /// <summary>
        /// Gets the Nundinal letter component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>Nundinal letters represent the day of the week.
        /// The Romans had an 8-day week (A-H) though every 2 years the days would shift to keep the calendar aligned 
        /// so 28th Feb might be an (A) but 1st Mar could be (D)</remarks>
        public NundinalLetters NundinalLetter => GetNundinalLetter();
        /// <summary>
        /// Gets the set day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>Set days are the three sacred days of the month in the Roman calendar:
        /// Kalendae, Nonae, Idus</remarks>
        public SetDays SetDay => RomanSetDay.SetDay;
        /// <summary>
        /// Gets the day prefix component of the Roman date represented by this instance.
        /// </summary>
        public DayPrefixes DayPrefix => RomanDayPrefix.Prefix;
        /// <summary>
        /// Gets the reference month component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>In the latter half of the month the Romans would start counting down to the Kalends of next month</remarks>
        public Months Month => ReferenceMonth.Month;
        /// <summary>
        /// Gets the time component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>The Romans would start counting from Hour 1 always from sunrise and have 12 hours until sunset 
        /// This means the length of the hour varies throughout the year, also night time was tracked by the passage of 
        /// the watches, or Vigia, which each for a quarter of the length of night time</remarks>
        public string Time => GetTime();
        /// <summary>
        /// Gets the hour component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>This is just another way to represent the time, with hours replacing the Vigila at night</remarks>
        public string Hour => GetTime(true);
        /// <summary>
        /// Gets the days until the next set day component of the Roman date represented by this instance.
        /// </summary>
        /// <remarks>This is an integer representation of the number of days until the next sacred day of the month 
        /// that makes up the representation of the day</remarks>
        public int? DaysUntilSetDay => _daysUntil == null ? GetDaysUntil() : _daysUntil;
        /// <summary>
        /// Gets the era component of the Roman date represented by this instance.
        /// </summary>
        public Eras Era { get; set; }

        private int? _daysUntil;

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

        internal LocalDateTime DateTimeData { get; }
        internal RomanMonths CalendarMonth => GetCalendarMonth();
        internal RomanMonths ReferenceMonth => GetReferenceMonth();
        internal RomanSetDays RomanSetDay => GetSetDay();
        internal RomanDayPrefixes RomanDayPrefix => GetDayPrefix();

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, Eras era = Eras.AD)
        {
            _daysUntil = null;
            DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, 1, 1, 0, era);
            Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the specified year and month.
        /// </summary>
        /// <param name="year">The year (1-9999).</param>
        /// <param name="month">The month (1-12).</param>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>
        public RomanDateTime(int year, int month, Eras era = Eras.AD)
        {
            _daysUntil = null;
            DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, 1, 0, era);
            Era = era;
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
            _daysUntil = null;
            DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, 0, era);
            Era = era;
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
            _daysUntil = null;
            DateTimeData = LocalDateTimeHelpers.ToLocalDateTime(year, month, day, hour, era);
            Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the <seealso cref="DateTime"/> provided.
        /// </summary>
        /// <param name="era">The era (AD/BC) defaults to AD if null.</param>        
        public RomanDateTime(DateTime date, Eras era = Eras.AD)
        {
            _daysUntil = null;
            DateTimeData = date.ToLocalDateTime(era);
            Era = era;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanDateTime"/> structure to the <seealso cref="LocalDateTime"/> provided.
        /// </summary>
        private RomanDateTime(LocalDateTime date)
        {
            _daysUntil = null;
            DateTimeData = date;
            Era = date.Year > 0 ? Eras.AD : Eras.BC;
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of hours to the value of this instance
        /// </summary>
        /// <param name="hours">A whole number of hours, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddHours(int hours)
        {
            return new RomanDateTime(DateTimeData.PlusHours(hours));
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of days to the value of this instance
        /// </summary>
        /// <param name="days">A whole number of days, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddDays(int days)
        {
            return new RomanDateTime(DateTimeData.PlusDays(days));
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of Roman weeks to the value of this instance
        /// </summary>
        /// <remarks>A Roman week is 8 days long so +1 weeks is the same as +8 days</remarks>
        /// <param name="weeks">A whole number of Roman weeks, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddWeeks(int weeks)
        {
            return new RomanDateTime(DateTimeData.PlusDays((weeks * 8)));
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of months to the value of this instance
        /// </summary>
        /// <param name="months">A whole number of months, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddMonths(int months)
        {
            return new RomanDateTime(DateTimeData.PlusMonths(months));
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of years to the value of this instance
        /// </summary>
        /// <param name="years">A whole number of years, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddYears(int years)
        {
            return new RomanDateTime(DateTimeData.PlusYears(years));
        }

        /// <summary>
        /// Converts this instance to a string in the format of {Time}, {Day} {Year} {Era}.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var date = $"{Time}, {Day} {Year}";

            if (Era == Eras.AD)
                return date;

            return $"{date} {Era}";
        }

        /// <summary>
        /// Formats Roman date time:
        /// > {t} = Time / {h} = hour / {v} = Vigila
        /// > {p/P} = short/full Prefix
        /// > {d} = Days until Set Day 
        /// > {sx/Sx} = short/full Set Day
        /// > {m/M} = short/full Month
        /// > {y/Yx} = Year/AUC Year
        /// > {e} = Era
        /// > {Dx} = Calendar day / {Dn} = Nundinal Letter
        /// > {cx/Cx} = short/full Calendar month
        /// </summary>
        /// <param name="format">The format for the Roman date e.g. {hx, p dx SD, M y}</param>
        public string ToString(string format)
        {
            format = format.Replace("p", "{0}");
            format = format.Replace("P", "{1}");
            format = format.Replace("d", "{2}");
            format = format.Replace("Dx", "{3}");
            format = format.Replace("sx", "{4}");
            format = format.Replace("Sx", "{5}");
            format = format.Replace("m", "{6}");
            format = format.Replace("M", "{7}");
            format = format.Replace("cx", "{8}");
            format = format.Replace("Cx", "{9}");
            format = format.Replace("y", "{10}");
            format = format.Replace("Yx", "{11}");
            format = format.Replace("t", "{12}");
            format = format.Replace("h", "{13}");
            format = format.Replace("v", "{14}");
            format = format.Replace("Dn", "{15}");
            format = format.Replace("e", "{16}");

            var sdAcc = DaysUntilSetDay != 0;
            var mAcc = DaysUntilSetDay > 1;
            var cMonth = CalendarMonth;
            var rMonth = ReferenceMonth;
            var sDay = RomanSetDay;
            var dPrefix = RomanDayPrefix;
            var vigila = Time.StartsWith("Vigila") ? Time : null;
            var calendarDay = DateTimeData.Day.ToRomanNumerals();

            return String.Format(format,
                dPrefix.Short, dPrefix.Long, DaysUntilSetDay.ToRomanNumerals(), calendarDay,
                sDay.Short, (sdAcc ? sDay.Accusative : sDay.Ablative),
                rMonth.Short, (mAcc ? rMonth.Accusative : rMonth.Ablative),
                cMonth.Short, cMonth.Month.ToString(), Year, AucYear, Time, Hour, vigila,
                NundinalLetter.ToString(), Era.ToString());
        }

        /// <summary>
        /// Converts this instance to a standard <see cref="DateTime"/> as well as the era it represents
        /// </summary>
        /// <returns>A <see cref="ValueTuple"/> containing a <seealso cref="DateTime"/> and <seealso cref="Eras"/></returns>
        public (DateTime DateTime, Eras Era) ToDateTime()
        {
            var date = DateTimeData;
            var dateTime = new DateTime(date.YearOfEra, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);

            return (dateTime, date.Year <= 0 ? Eras.BC : Eras.AD);
        }

        /// <summary>
        /// Tries to parse the provided string into a valid <see cref="RomanDateTime"/>
        /// </summary>
        /// <param name="value">The string value of the Roman date you wish to try to parse</param>
        /// <param name="dateTime">The parsed Roman date if successful</param>
        /// <returns>True if parse successful</returns>
        public bool TryParse(string value, out RomanDateTime dateTime)
        {
            return RomanDateParser.TryParse(value, out dateTime);
        }

        #region Private Methods

        private NundinalLetters GetNundinalLetter()
        {
            var year = DateTimeData.YearOfEra;

            var startPosition = (NundinalLetters)(year % 8);

            var daysFromStart = Math.Abs(DateTimeData.Minus(new LocalDateTime(DateTimeData.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = (((daysFromStart + (int)startPosition) - 1) % 8);

            if (daysFromCycle > 8)
                daysFromCycle -= 8;

            var cyclePosition = (NundinalLetters)daysFromCycle;

            return cyclePosition;
        }

        private string GetRomanDayString(bool shorten = false)
        {
            var sb = new StringBuilder();
            var rMonth = ReferenceMonth;
            var sDay = RomanSetDay;
            var dPrefix = RomanDayPrefix;

            sb.Append($"{(shorten ? dPrefix.Short : dPrefix.Long)} ");

            if (DaysUntilSetDay > 2)
                sb.Append($"{DaysUntilSetDay.ToRomanNumerals()} ");

            if (DaysUntilSetDay == 0)
                sb.Append($"{(shorten ? sDay.Short : sDay.Ablative)} ");
            else
                sb.Append($"{(shorten ? sDay.Short : sDay.Accusative)} ");

            if (DaysUntilSetDay > 2)
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Accusative)}");
            else
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Ablative)}");

            return sb.ToString().TrimStart();
        }

        private string GetRomanYear()
        {
            return DateTimeData.YearOfEra.ToRomanNumerals();
        }

        private string GetAucYear()
        {
            var auc = 753;
            var year = (auc += DateTimeData.Year);
            return year <= 0 ? "" : year.ToRomanNumerals();
        }

        private string GetTime(bool hour = false)
        {
            var cMonth = CalendarMonth;
            var current = DateTimeData.TimeAsFraction();
            var dayHours = 0;
            var nightHours = 0;

            for (var x = 0; current > 0.1; x++)
            {
                if (x < 6 || x.Between(18, 23))
                {
                    nightHours++;
                    current -= cMonth.HourLengthNight;
                }
                else if (x.Between(6, 17))
                {
                    dayHours++;
                    current -= cMonth.HourLengthDay;
                }
            }

            if ((nightHours > 0 && dayHours == 0) || nightHours > 6)
            {
                if (nightHours.Between(7, 9))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Prima";
                if (nightHours.Between(10, 12))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Secunda";
                if (nightHours.Between(1, 3))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Tertia";
                if (nightHours.Between(4, 6))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Quarta";
            }
            else if (dayHours != 0)
            {
                return $"hora {dayHours.ToRomanNumerals()}";
            }

            return hour ? $"hora noctis VII" : $"Vigila Tertia";
        }

        private RomanMonths GetReferenceMonth()
        {
            if (DateTimeData.Day != 1 && RomanSetDay.SetDay == SetDays.Kalendae)
                return RomanMonths.GetRomanMonth(CalendarMonth.Month.Next());

            return CalendarMonth;
        }

        private RomanDayPrefixes GetDayPrefix()
        {
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

            if (day.In(new int[] { cMonth.Kalendae, cMonth.Nonae, cMonth.Idus }))
                return new RomanDayPrefixes();
            else if (day.In(new int[]
                {
                    cMonth.Nonae - 1, cMonth.Idus - 1, cMonth.End + (leapYear &&
                        cMonth.Month == Months.Februarius ? 1 : 0)
                }))
                return RomanDayPrefixes.Pridie;
            else if (day == 24 && cMonth.Month == Months.Februarius && leapYear)
                return RomanDayPrefixes.AnteDiemBis;

            return RomanDayPrefixes.AnteDiem;
        }

        private RomanSetDays GetSetDay()
        {
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false) || day == cMonth.Nonae)
                return RomanSetDays.Nonae;
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false) || day == cMonth.Idus)
                return RomanSetDays.Idus;

            return RomanSetDays.Kalendae;
        }

        private int GetDaysUntil()
        {
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false))
                return (cMonth.InterKalendae + 1) - ((day - cMonth.Kalendae) - 1);
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false))
                return (cMonth.InterNonae + 1) - ((day - cMonth.Nonae) - 1);
            else if (day.Between(cMonth.Idus, cMonth.End + (leapYear &&
                    cMonth.Month == Months.Februarius ? 1 : 0), false))
            {
                var daysBeforeKalendis = (cMonth.InterIdus + 1) - ((day - cMonth.Idus) - 1);

                if (leapYear && cMonth.Month == Months.Februarius && day <= 24)
                    return daysBeforeKalendis;
                if (leapYear && cMonth.Month == Months.Februarius && day > 24)
                    return daysBeforeKalendis + 1;
                else
                    return daysBeforeKalendis;
            }

            return 0;
        }

        private RomanMonths GetCalendarMonth()
        {
            if (DateTimeData.Month != 0 && DateTimeData.Month <= 12)
            {
                return (RomanMonths.GetRomanMonth((Months)DateTimeData.Month));
            }

            return default(RomanMonths);
        }

        #endregion
    }
}