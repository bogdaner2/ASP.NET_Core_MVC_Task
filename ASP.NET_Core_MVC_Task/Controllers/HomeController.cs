using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_MVC_Task.Models;
using HTTP_LINQ_Practice;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Users = QueryService.Users[0].Name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
