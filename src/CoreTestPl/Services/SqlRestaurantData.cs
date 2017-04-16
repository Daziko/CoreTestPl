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
            this.context = context;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            context.Add(newRestaurant);
            return newRestaurant;
        }

        public void Comit()
        {
            context.SaveChanges();
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
