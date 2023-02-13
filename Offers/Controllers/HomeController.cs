using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Offers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}