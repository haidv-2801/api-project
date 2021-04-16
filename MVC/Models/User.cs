using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
    }
}