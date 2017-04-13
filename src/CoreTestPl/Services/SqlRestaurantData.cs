using System;
using System.Collections.Generic;
using System.Linq;
using CoreTestPl.Entities;

namespace CoreTestPl.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        readonly OdeToFoodDbContext context;
        public SqlRestaurantData(OdeToFoodDbContext context)
        {

        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            context.Add(newRestaurant);
            context.SaveChanges();
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return context.Restaurants;
        }
    }
}
