using CoreTestPl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestPl.WievModels
{
    public class HomePageViewModel
    {
        public string CurrentMessageOfTheDay { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
