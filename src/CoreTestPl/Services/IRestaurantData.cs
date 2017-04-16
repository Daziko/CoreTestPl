using CoreTestPl.Entities;
using System.Collections.Generic;

namespace CoreTestPl.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        void Comit();
    }
}
