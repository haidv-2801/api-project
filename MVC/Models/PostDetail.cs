using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PostDetail
    {
        public string id { get; set; }
        public string message { get; set; }
        public string link { get; set; }
        public string full_picture { get; set; }
        public string created_time { get; set; }
    }
}