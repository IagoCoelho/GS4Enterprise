using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Enterprise2._0.Controllers
{
    public class HomeController : Controller
    {
        public readonly ContextNew _ContextNew;

        public HomeController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
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
