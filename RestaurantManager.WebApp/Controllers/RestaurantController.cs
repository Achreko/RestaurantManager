using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestaurantManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.WebApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IConfiguration Configuration;

        List<RestaurantVM> restaurantsList = new List<RestaurantVM>();

        public RestaurantController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }
        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();

            using (var htppClient = new HttpClient())
            {
                using (var response = await htppClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurantsList = JsonConvert.DeserializeObject<List<RestaurantVM>>(apiResponse);
                }
            }
            return View(restaurantsList);
        }


        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM s = new RestaurantVM();
            using (var htppClient = new HttpClient())
            {
                using (var response = await htppClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<RestaurantVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantVM s)
        {
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM result = new RestaurantVM();

            try
            {
                using (var htppClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await htppClient.PutAsync($"{_restpath}/{s.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        s = JsonConvert.DeserializeObject<RestaurantVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            //string _restpath = "https://localhost:5000/SkiJumper";
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM s = new RestaurantVM();
            using (var htppClient = new HttpClient())
            {
                using (var response = await htppClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<RestaurantVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RestaurantVM s)
        {
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM result = new RestaurantVM();

            try
            {
                using (var htppClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    await htppClient.DeleteAsync($"{_restpath}/{s.Id}");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            //string _restpath = "https://localhost:5000/SkiJumper";
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM s = new RestaurantVM();

            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantVM s)
        {
            string _restpath = GetHostUrl().Content + CN();

            RestaurantVM result = new RestaurantVM();

            try
            {
                using (var htppClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await htppClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        s = JsonConvert.DeserializeObject<RestaurantVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
