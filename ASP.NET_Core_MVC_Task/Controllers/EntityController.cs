﻿using System.Linq;
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

        [HttpPost]
        public IActionResult Select(int id,string type)
        {
            switch (type)
            {
                case "comment": return RedirectToAction("Comments", new { id = id });
                case "user": return RedirectToAction("Users", new { id = id });
                case "post": return RedirectToAction("Posts", new { id = id });
                case "todo": return RedirectToAction("Todos", new { id = id });
            }
            return NoContent();
        }

        public IActionResult Users(int id)
        {
            var user = QueryService.FindUser(id);
            if (user == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(user);
        }
        public IActionResult Posts(int id)
        {
            var post = QueryService.FindPost(id);
            if (post == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(post);
        }
        public IActionResult Todos(int id)
        {
            var todos = QueryService.FindTodo(id);
            if (todos == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(todos);
        }
        public IActionResult Comments(int id)
        {
            var comment = QueryService.FindComment(id);
            if (comment == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(comment);
        }
    }
}