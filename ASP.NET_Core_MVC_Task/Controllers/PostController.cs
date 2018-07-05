using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}