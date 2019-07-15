using System.Collections.Generic;

namespace API.RomanDate.ViewModels
{
    public class RomanDateViewModel
    {
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public string ConsularYear { get; set; } = "";
        public string Day { get; set; } = "";
        public string Month { get; set; } = "";
        public string CalendarMonth { get; set; } = "";
        public string Time { get; set; } = "";
        public string Date { get; set; } = "";
        public string AucDate { get; set; } = "";
        public string NundinalLetter { get; set; } = "";
        public bool IsNundinae { get; set; }
        public IEnumerable<MagistrateSimpleViewModel> RulingMagistrates { get; set; } = new List<MagistrateSimpleViewModel>();
    }
}