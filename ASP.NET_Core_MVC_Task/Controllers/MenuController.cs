using System.Linq;
using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
