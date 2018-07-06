using System.Linq;
using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class EntityController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Select(int Id,string type)
        {
            if (type == "comment")
            {
                return RedirectToAction("Comments", new {Id = Id});
            }
            else if (type == "user")
            {
                return RedirectToAction("Users", new { Id = Id });
            }
            else if (type == "post")
            {
                return RedirectToAction("Posts", new {Id = Id});
            }
            else
            {
                return RedirectToAction("Todos", new { Id = Id });
            }
        }

        public IActionResult Users(int Id)
        {
            return View();
        }
        public IActionResult Posts(int Id)
        {
            return View();
        }
        public IActionResult Todos()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Comments(int Id)
        {
            var comment = QueryService.Users
                .SelectMany(u => u.Posts)
                .SelectMany(p => p.Comments)
                .FirstOrDefault(c => c.Id == Id);
            if (comment == null)
            {
                return View("~/Views/Entity/Error.cshtml");
            }
            return View(comment);
        }
    }
}