using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ufrSet.Models;

namespace ufrSet.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Maths()
        {
            return View();
        }

        public IActionResult Pc()
        {
            return View();
        }

        public IActionResult Eau()
        {
            return View();
        }

        public IActionResult Li()
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