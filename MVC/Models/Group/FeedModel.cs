using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Group
{
    public class FeedModel
    {
        public class Data
        {
            public string id { get; set; }
            public string message { get; set; }
            public string caption { get; set; }
        }

        public List<Data> data { get; set; }
    }
}