using System;
using System.Collections.Generic;
using ASP.NET_Core_MVC_Task.Models.Entity;

namespace ASP.NET_Core_MVC_Task.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public List<Post> Posts { get; set; }
        public List<ToDo> ToDos { get; set; }
        public List<Comment> UserComments { get; set; }
        public Address Address { get; set; }
    }
}

