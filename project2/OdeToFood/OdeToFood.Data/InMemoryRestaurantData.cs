using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            this.restaurants.Add(newRestaurant);
            newRestaurant.Id = this.restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }

        public int Comit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = this.restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant!= null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return this.restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
