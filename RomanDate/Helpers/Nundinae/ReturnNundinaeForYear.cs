using System.Linq;
using NodaTime;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        public static NundinalLetters ReturnNundinaeForYear(LocalDateTime dateTime)
        {
            var startPosition = (NundinalLetters)(dateTime.YearOfEra % 8);
            var enumList = EnumEx.EnumToList<NundinalLetters>();
            var checkDates = CheckNundialLetters(dateTime, startPosition);

            var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

            if (result.Any())
                return result.First();

            var countResult = checkDates.GroupBy(i => i).OrderBy(g => g.Count()).Select(g => g.Key).ToList();

            return countResult.First();
        }
    }
}