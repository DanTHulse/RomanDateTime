using System.Collections.Generic;

namespace API.RomanDate.ViewModels
{
    public class MagistrateViewModel
    {
        public string Name { get; set; } = "";
        public IEnumerable<ElectedViewModel> ElectedOffices = new List<ElectedViewModel>();
    }

    public class ElectedViewModel
    {
        public string Office { get; set; } = "";
        public int YearElected { get; set; } = 0;
    }
}
