using CoreTestPl.Entities;
using System.Collections.Generic;

namespace CoreTestPl.WievModels
{
    public class HomePageViewModel
    {
        public string CurrentMessageOfTheDay { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
