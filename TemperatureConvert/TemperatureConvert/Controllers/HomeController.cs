using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemperatureConvert.Models;

namespace TemperatureConvert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new TemperatureConversionViewModel());
        }

        [HttpPost]
        public IActionResult Index(TemperatureConversionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.FromTemperature == TemperatureUnit.Fahrenheit)
                {
                    model = model with { Celsius = (model.Fahrenheit - 32) * 5 / 9};
                }
                else
                {
                    model = model with
                    {
                        Fahrenheit = (model.Celsius * 9.0 / 5.0) + 32
                    };
                }
            }

            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
