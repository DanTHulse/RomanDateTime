﻿using System.Collections.Generic;
using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarDayViewModel
    {
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public string Day { get; set; } = "";
        public string Month { get; set; } = "";
        public string NundinalLetter { get; set; } = "";
        public bool IsNundinae { get; set; }
        public IEnumerable<CalendarEventViewModel> Events { get; set; } = new List<CalendarEventViewModel>();
        public Navigation _Navigation { get; set; } = new Navigation();
    }
}
