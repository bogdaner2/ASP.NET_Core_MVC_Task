using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult GetCommentsInPost()
        {
            var result = QueryService.GetCommentsInPost(3);
            ViewBag.result = result;
            return View();
        }

        //public IActionResult GetUserComments(int userId)
        //{
        //    return View();
        //}

        //public IActionResult UserSortByTodo(int userId)
        //{
        //    return View();
        //}

        //public IActionResult UserTodoDone(int userId)
        //{
        //    return View();
        //}

        //public IActionResult GetStruct_User(int userId)
        //{
        //    return View();
        //}

        //public IActionResult GetStruct_Post(int userId)
        //{
        //    return View();
        //}
    }
}