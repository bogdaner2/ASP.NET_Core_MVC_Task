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
        public IActionResult Select(int id, string type,int maxLenth = 50)
        {
            switch (type)
            {
                case "comInPost": return RedirectToAction("CommentsInPost", new { id = id });
                case "comByLen": return RedirectToAction("UserComments", new { id = id, maxLenth = maxLenth });
                case "todoDone": return RedirectToAction("UserTodoDone", new { id = id });
                case "sortByTodo": return RedirectToAction("UserSortByTodo");
                case "userStruct": return RedirectToAction("UserStruct", new { id = id });
                case "postStruct": return RedirectToAction("PostStruct", new {id = id});
            }
            return NoContent();
        }

        public IActionResult CommentsInPost(int id)
        {
            var result = QueryService.GetCommentsInPost(id);
            if (result == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserComments(int id,int maxLenth)
        {
            var result = QueryService.GetUserComments(id,maxLenth);
            if (result == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            ViewBag.User = QueryService.FindUser(id);
            ViewBag.MaxLength = maxLenth;
            return View(result);
        }

        public IActionResult UserTodoDone(int id)
        {
            var result = QueryService.UserTodoDone(id);
            if (result == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            ViewBag.result = result;
            ViewBag.User = QueryService.FindUser(id);
            return View();
        }

        public IActionResult UserSortByTodo()
        {
            var result = QueryService.UserSortByTodo();
            return View(result);
        }

        public IActionResult UserStruct(int id)
        {
            var result = QueryService.GetStruct_User(id);
            if (result == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(result);
        }

        public IActionResult PostStruct(int id)
        {
            var result = QueryService.GetStruct_Post(id);
            if (result == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(result);
        }

    }
}