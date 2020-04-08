using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ApplicationDbContext context;
        public SqlRestaurantData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            this.context.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Comit()
        {
            return this.context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = this.context.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                this.context.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return this.context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in this.context.Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = this.context.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }
    }
}
