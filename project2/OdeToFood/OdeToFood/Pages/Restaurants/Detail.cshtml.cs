using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantData;
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            this.Restaurant = this.restaurantData.GetRestaurantsById(restaurantId);
            if(this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}