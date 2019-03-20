namespace DateTimeEra
{
    public static class DateTimeErasConstants
    {
        public const int MaxYear = 9999;
        public const int MinYear = -9999;
        public static readonly int[] DaysInMonth365 = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 31, 31 };
        public static readonly int[] DaysInMonth366 = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 31, 31 };
    }
}