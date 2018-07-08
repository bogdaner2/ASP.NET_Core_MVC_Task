using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult UserPage()
        {
            var users = QueryService.Users;
            return View(users);
        }
    }
}