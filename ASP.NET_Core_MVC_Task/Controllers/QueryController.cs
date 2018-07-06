using ASP.NET_Core_MVC_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Task.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Select(int Id, string type,int maxLenth = 50)
        {
            if (type == "comment")
            {
                return RedirectToAction("CommentsInPost", new { Id = Id });
            }
            return NoContent();
            //else if (type == "user")
            //{
            //   // return RedirectToAction("Users", new { Id = Id });
            //}
            //else if (type == "post")
            //{
            //   // return RedirectToAction("Posts", new { Id = Id });
            //}
            //else
            //{
            //   // return RedirectToAction("Todos", new { Id = Id });
            //}
        }

        public IActionResult CommentsInPost(int Id)
        {
            var result = QueryService.GetCommentsInPost(Id);
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserComments(int Id,int maxLenth)
        {
            var result = QueryService.GetUserComments(Id,maxLenth);
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserTodoDone(int Id)
        {
            var result = QueryService.UserTodoDone(Id);
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserSortByTodo()
        {
            var result = QueryService.UserSortByTodo();
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserStruct(int Id)
        {
            var result = QueryService.GetStruct_User(Id);
            ViewBag.result = result;
            return View();
        }

        public IActionResult PostStruct(int Id)
        {
            var result = QueryService.GetStruct_Post(Id);
            ViewBag.result = result;
            return View();
        }

    }
}