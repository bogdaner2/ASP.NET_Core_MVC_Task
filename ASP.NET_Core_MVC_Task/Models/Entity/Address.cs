namespace ASP.NET_Core_MVC_Task.Models.Entity
{
        public class Address
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Zip { get; set; }
            public int UserId { get; set; }
        }
}
