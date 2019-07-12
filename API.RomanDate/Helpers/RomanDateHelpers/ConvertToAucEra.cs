using RomanDate.Enums;

namespace API.RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        public static int ConvertToAucEra(Eras era, int year)
            => era == Eras.AD ? year + 753 : year > 753 ? 0 : 753 - (year - 1);
    }
}
