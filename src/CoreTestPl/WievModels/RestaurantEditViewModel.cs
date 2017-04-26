using CoreTestPl.Entities;
using System.ComponentModel.DataAnnotations;

namespace CoreTestPl.WievModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
