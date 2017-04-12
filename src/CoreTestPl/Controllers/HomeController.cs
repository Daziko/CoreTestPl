using CoreTestPl.Entities;
using CoreTestPl.Services;
using CoreTestPl.WievModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreTestPl.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData restaurantData;
        private IGreeter greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            if (restaurantData == null)
            {
                throw new ArgumentException(nameof(restaurantData));
            }
            if (greeter == null)
            {
                throw new ArgumentException(nameof(greeter));
            }
            this.restaurantData = restaurantData;
            this.greeter = greeter;   
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Restaurants = restaurantData.GetAll(),
                CurrentMessageOfTheDay = greeter.GetGreeting()           
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = restaurantData.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model )
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Cuisine = model.Cuisine,
                    Name = model.Name
                };

                newRestaurant = restaurantData.Add(newRestaurant);

                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }

            return View();
        }
    }
}
