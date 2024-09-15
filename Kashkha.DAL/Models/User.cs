using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL.Models
{
    public class User:IdentityUser
    {

        public string? ShopName { get; set; }
        public string Rolename { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Category { get; set; }
        public string? ImgUrl { get; set; }
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; } = Enumerable.Empty<Order>();
        [JsonIgnore]

        public Guid? Shop { get; set; }
       
    }
}
