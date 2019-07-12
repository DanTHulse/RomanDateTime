﻿using System.Collections.Generic;

namespace API.RomanDate.ViewModels
{
    public class MagistrateViewModel
    {
        public string Name { get; set; } = "";
        public IEnumerable<ElectedViewModel> ElectedOffices { get; set; } = new List<ElectedViewModel>();
    }
}
