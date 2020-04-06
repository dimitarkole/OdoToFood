using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants  { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,
            IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm = null)
        {

            this.Message = configuration["Message"];
            this.Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}