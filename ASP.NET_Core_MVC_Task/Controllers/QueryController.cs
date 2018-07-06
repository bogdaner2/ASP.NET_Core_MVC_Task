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
            if (type == "comInPost")
            {
                return RedirectToAction("CommentsInPost", new { id = id });
            }
            else if (type == "comByLen")
            {
                 return RedirectToAction("UserComments", new { id = id ,maxLenth = maxLenth });
            }

            else if (type == "todoDone")
            {
                return RedirectToAction("UserTodoDone", new { id = id });
            }
            return NoContent();
            //else if (type == "post")
            //{
            //    // return RedirectToAction("Posts", new { id = id });
            //}
            //else if (type == "post")
            //{
            //    // return RedirectToAction("Posts", new { id = id });
            //}
            //else if (type == "post")
            //{
            //    // return RedirectToAction("Posts", new { id = id });
            //}
            //else
            //{
            //     return RedirectToAction("PostStruct", new { id = id });
            //}
        }

        public IActionResult CommentsInPost(int id)
        {
            var result = QueryService.GetCommentsInPost(id);
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserComments(int id,int maxLenth)
        {
            var result = QueryService.GetUserComments(id,maxLenth);
            ViewBag.User = QueryService.FindUser(id);
            ViewBag.MaxLength = maxLenth;
            return View(result);
        }

        public IActionResult UserTodoDone(int id)
        {
            var result = QueryService.UserTodoDone(id);
            ViewBag.result = result;
            ViewBag.User = QueryService.FindUser(id);
            return View();
        }

        public IActionResult UserSortByTodo()
        {
            var result = QueryService.UserSortByTodo();
            ViewBag.result = result;
            return View();
        }

        public IActionResult UserStruct(int id)
        {
            var result = QueryService.GetStruct_User(id);
            ViewBag.result = result;
            return View();
        }

        public IActionResult PostStruct(int id)
        {
            var result = QueryService.GetStruct_Post(id);
            ViewBag.result = result;
            return View();
        }

    }
}