using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Page
{
    public class PagePostModel
    {
        public class ListGRId
        {
            public string id { get; set; }
            public string access_token { get; set; }
        }
        public List<ListGRId> listGroupId { get; set; }
        public string message { get; set; }
        public string link { get; set; }
        public string isPublished { get; set; }
    }
    
}