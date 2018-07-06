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
            var user = QueryService.Users
                .FirstOrDefault(u => u.Id == Id);
            if (user == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(user);
        }
        public IActionResult Posts(int Id)
        {
            var post = QueryService.Users
                .SelectMany(u => u.Posts)
                .FirstOrDefault(p => p.Id == Id);
            if (post == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(post);
        }
        public IActionResult Todos(int Id)
        {
            var todos = QueryService.Users
                .SelectMany(t => t.ToDos)
                .FirstOrDefault(t => t.Id == Id);
            if (todos == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(todos);
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
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(comment);
        }
    }
}