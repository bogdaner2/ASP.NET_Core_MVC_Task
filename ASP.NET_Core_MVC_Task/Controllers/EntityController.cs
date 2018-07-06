using System.Linq;
using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class EntityController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Posts()
        {
            return View();
        }
        public IActionResult Todos()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Comments(int commentId)
        {
            var comment = QueryService.Users
                .SelectMany(u => u.Posts)
                .SelectMany(p => p.Comments)
                .FirstOrDefault(c => c.Id == commentId);
            return View(comment);
        }
    }
}