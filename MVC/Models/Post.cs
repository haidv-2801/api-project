using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Post
    {
        public List<string> listGroupId { get; set; }
        public string message { get; set; }
        public string link { get; set; }
    }
}