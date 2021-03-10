using RomanDateTime.Enums;

namespace RomanDate.Definitions
{
    public struct RomanDayPrefixes
    {
        public DayPrefixes Prefix { get; }

        internal string Long { get; }

        internal string Short { get; }

        public static RomanDayPrefixes AnteDiem => new(DayPrefixes.AnteDiem, "ante diem", "a.d.");

        public static RomanDayPrefixes AnteDiemBis => new(DayPrefixes.AnteDiemBis, "ante diem bis", "a.d. b.");

        public static RomanDayPrefixes Pridie => new(DayPrefixes.Pridie, "pridie", "pr.");

        private RomanDayPrefixes(DayPrefixes prefix = DayPrefixes.None, string longV = "", string shortV = "")
        {
            this.Prefix = prefix;
            this.Long = longV;
            this.Short = shortV;
        }
    }
}
