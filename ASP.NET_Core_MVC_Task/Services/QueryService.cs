using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_MVC_Task.Models.Entity;

namespace ASP.NET_Core_MVC_Task.Models
{
     static class QueryService
     {
        public static List<User> Users { get; set; }
        public static List<Address> Adress { get; set; }
        public static List<(Post,int)> GetCommentsInPost(int userId)
        {     
            var result = Users
                .FirstOrDefault(u => u.Id == userId)?
                .Posts
                .Select(p => (p,p.Comments.Count))
                .ToList();
            return result;
        }
        public static List<Comment> GetUserComments(int userId,int maxLenth)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var result = user.Posts
                    .SelectMany(p => p.Comments)
                    .Where(c => c.Body.Length < maxLenth);
                return result.ToList();
            }
            return null;
        }
        public static List<(int, string)> UserTodoDone(int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var result = from toDo in user.ToDos
                    where toDo.IsComplete == true
                    select (toDo.Id, toDo.Name);
                return result.ToList();
            }        
            return null;
        }
        public static List<User> UserSortByTodo()
        {
            var result = Users.OrderBy(u => u.Name)
                .Select(x => { x.ToDos =
                x.ToDos.OrderByDescending(t => t.Name.Length).ToList();
                return x;
            });
        return result.ToList();
        }
        public static QueryStructUser GetStruct_User(int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            var lastPost = user?.Posts.FirstOrDefault(post => post.CreatedAt == user.Posts.Max(p => p.CreatedAt));
            if (lastPost == null) return null;
            var countPostComment = lastPost.Comments.Count;
            var nonCompleteTasks = user.ToDos.Count(t => t.IsComplete == false);
            var popularPostLike = user.Posts.OrderByDescending(p => p.Likes).FirstOrDefault();
            var popularPostComm = user.Posts
                .Select(p =>
            {
                p.Comments = p.Comments.Where(c => c.Body.Length > 80).ToList();
                return p;
            })
                .OrderByDescending(p => p.Comments.Count)
                .FirstOrDefault();
            return new QueryStructUser(user,lastPost,countPostComment,nonCompleteTasks,popularPostLike,popularPostComm); 
        }
        public static QueryStructPost GetStruct_Post(int postId)
        {
            var post = Users.SelectMany(x => x.Posts).FirstOrDefault(p => p.Id == postId);
            if (post == null) return null;
            var longestComment = post.Comments.OrderByDescending(c => c.Body.Length).FirstOrDefault();
            var mostLikestComment = post.Comments.OrderByDescending(c => c.Likes).FirstOrDefault();
            var commCount = post.Comments.Count(c => c.Likes == 0 || c.Body.Length < 80);
            return new QueryStructPost(post,longestComment,mostLikestComment,commCount);
        }
        public static User FindUser(int id)
        {
             return Users.FirstOrDefault(u => u.Id == id);
        }
        public static Post FindPost(int id)
        {
            return Users
                .SelectMany(u => u.Posts)
                .FirstOrDefault(p => p.Id == id);
        }
        public static ToDo FindTodo(int id)
        {
            return Users
                 .SelectMany(t => t.ToDos)
                 .FirstOrDefault(t => t.Id == id);
        }
        public static Comment FindComment(int id)
        {
            return QueryService.Users
                .SelectMany(u => u.Posts)
                .SelectMany(p => p.Comments)
                .FirstOrDefault(c => c.Id == id);
        }

    }
}
