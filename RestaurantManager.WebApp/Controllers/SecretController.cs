using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.WebApp.Controllers
{
    [Authorize(Roles = "Premium,Admin")]
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
