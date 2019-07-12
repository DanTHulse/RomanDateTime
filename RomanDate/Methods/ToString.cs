using RomanDate.Enums;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Converts this instance to a string in the format of {Time}, {Day} {Year} {Era}.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var date = $"{this.Time}, {this.Day} {this.Year}";

            if (this.Era == Eras.AD)
                return date;

            return $"{date} {this.Era}";
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
        /// > {z/Z} = short/full Complete Roman Day
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
            format = format.Replace("z", "{17}");
            format = format.Replace("Z", "{18}");

            var sdAcc = this.DaysUntilSetDay != 0;
            var mAcc = this.DaysUntilSetDay > 1;
            var cMonth = this.CalendarMonth;
            var rMonth = this.ReferenceMonth;
            var sDay = this.RomanSetDay;
            var dPrefix = this.RomanDayPrefix;
            var vigila = this.Time.StartsWith("Vigila") ? this.Time : null;
            var calendarDay = this.DateTimeData.Day.ToRomanNumerals();

            return string.Format(format,
                dPrefix.Short, dPrefix.Long, this.DaysUntilSetDay.ToRomanNumerals(), calendarDay,
                sDay.Short, (sdAcc ? sDay.Accusative : sDay.Ablative),
                rMonth.Short, (mAcc ? rMonth.Accusative : rMonth.Ablative),
                cMonth.Short, cMonth.Month.ToString(), this.Year, this.AucYear, this.Time, this.Hour, vigila,
                this.NundinalLetter.ToString(), this.Era.ToString(), this.GetRomanDayString(true), this.GetRomanDayString());
        }
    }
}