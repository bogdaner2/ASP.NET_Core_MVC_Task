namespace ASP.NET_Core_MVC_Task.Models
{
    public class QueryStructUser
    {
        public User User { get; set; }
        public Post LastPost { get;  }
        public int CountPostComments { get; set; }
        public int NonCompleteTasks { get; set; }
        public Post PopularPostLike { get; set; }
        public Post PopularPostComm { get; set; }

        public QueryStructUser(User user,
            Post lastPost,
            int countPostComments,
            int nonCompleteTasks,
            Post popularPostLike,
            Post popularPostComm)
        {
            User = user;
            LastPost = lastPost;
            CountPostComments = countPostComments;
            NonCompleteTasks = nonCompleteTasks;
            PopularPostLike = popularPostLike;
            PopularPostComm = popularPostComm;
        }
    }
}
