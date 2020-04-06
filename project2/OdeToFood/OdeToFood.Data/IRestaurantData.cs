using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Cuisine = CuisineType.Indian, Location = "Maryland", Name = "My pizza!"},
                new Restaurant {Id = 2, Cuisine = CuisineType.Mexican, Location = "Smolian", Name = "My Club!"},
                new Restaurant {Id = 3, Cuisine = CuisineType.Indian, Location = "Sofia", Name = "Lacosta"},
            };

        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
