using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData,
            IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                this.Restaurant = this.restaurantData.GetRestaurantsById(restaurantId.Value);
            }
            else
            {
                this.Restaurant = new Restaurant();
            }
            if (this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (!ModelState.IsValid){
                this.restaurantData.Comit();
                return Page();
            }
            if(this.Restaurant.Id>0)
            {
                this.Restaurant = this.restaurantData.Update(this.Restaurant);

            }
            else
            {
                this.Restaurant = this.restaurantData.Add(this.Restaurant);

            }
            this.TempData["Message"] = "Restaurant saved!";
            return Page();
        }
    }
}