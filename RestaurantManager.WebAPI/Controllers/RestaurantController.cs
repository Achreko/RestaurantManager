using Microsoft.AspNetCore.Mvc;
using RestaurantManager.Infrastructure.Commands;
using RestaurantManager.Infrastructure.DTO;
using RestaurantManager.Infrastructure.Services;
using System.Threading.Tasks;

namespace RestaurantManager.WebAPI.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _restaurantService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var z = await _restaurantService.GetRestaurant(id);
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetSkiJumper(string country)
        {
            var z = await _restaurantService.BrowseAllFilter(country);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateRestaurant restaurant)
        {
            var s = new RestaurantDTO()
            {
                Country = restaurant.Country,
                Name = restaurant.Name,
                NumberOfEmployees = restaurant.NumberOfEmployees,
                DateOfOpening = restaurant.DateOfOpening
            };
            await _restaurantService.AddRestaurant(s);
            return Json(s);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditSkiJumper([FromBody] UpdateRestaurant restaurant, int id)
        {
            var r = new RestaurantDTO()
            {
                Id = id,
                MonthlyRevenue = restaurant.MonthlyRevenue,
                Name = restaurant.Name,
                NumberOfEmployees = restaurant.NumberOfEmployees,
            };
            await _restaurantService.UpdateRestaurant(r);
            return Json(r);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            var z = new RestaurantDTO()
            {
                Id = id
            };
            await _restaurantService.DeleteRestaurant(z);
            return NoContent();
        }
    }
}
