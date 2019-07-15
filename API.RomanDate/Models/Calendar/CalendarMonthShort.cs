using API.RomanDate.Models.Base;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarMonthShort
    {
        public int Number { get; set; }
        public Months Month { get; set; }
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
