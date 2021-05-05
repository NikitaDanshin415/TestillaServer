using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ClassLibrary2.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [JsonIgnore]
        public int roleId { get; set; }
        public Role role { get; set; }
    }
}
