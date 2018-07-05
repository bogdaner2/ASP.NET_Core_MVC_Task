using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HTTP_LINQ_Practice;
using Newtonsoft.Json;

namespace ASP.NET_Core_MVC_Task.Services
{
    public class LoadDataService
    {
        public void LoadData()
        {
            var users = DownloadDataAsync<List<User>>("https://5b128555d50a5c0014ef1204.mockapi.io/users").Result;
            var posts = DownloadDataAsync<List<Post>>("https://5b128555d50a5c0014ef1204.mockapi.io/posts").Result;
            var todos = DownloadDataAsync<List<ToDo>>("https://5b128555d50a5c0014ef1204.mockapi.io/todos").Result;
            var comments = DownloadDataAsync<List<Comment>>("https://5b128555d50a5c0014ef1204.mockapi.io/comments").Result;
            posts.ForEach(p => p.Comments = comments.Where(c => c.PostId == p.Id).ToList());
            users.ForEach(user => user.Posts = posts.Where(x => x.UserId == user.Id).ToList());
            users.ForEach(user => user.ToDos = todos.Where(x => x.UserId == user.Id).ToList());
            QueryService.Users = users;
            
        }
        private async Task<T> DownloadDataAsync<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string responsJson = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responsJson);
            }
        }
    }
}
