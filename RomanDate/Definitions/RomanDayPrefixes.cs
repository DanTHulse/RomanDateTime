using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public struct RomanDayPrefixes
    {
        public DayPrefixes Prefix { get; }
        public string Long { get; }
        public string Short { get; }

        public static RomanDayPrefixes AnteDiem => new RomanDayPrefixes(DayPrefixes.AnteDiem, "ante diem", "a.d.");
        public static RomanDayPrefixes AnteDiemBis => new RomanDayPrefixes(DayPrefixes.AnteDiemBis, "ante diem bis", "a.d. b.");
        public static RomanDayPrefixes Pridie => new RomanDayPrefixes(DayPrefixes.Pridie, "pridie", "pr.");

        public RomanDayPrefixes(DayPrefixes prefix = DayPrefixes.None, string longV = "", string shortV = "")
        {
            Prefix = prefix;
            Long = longV;
            Short = shortV;
        }
    }
}
