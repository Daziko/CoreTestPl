using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTestPl.Entities;

namespace CoreTestPl.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> restaurants;
        static InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Sattory Stage" },
                new Restaurant {Id = 2, Name = "Nervosa" },
                new Restaurant {Id = 3, Name = "Budha" }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }
    }
}
