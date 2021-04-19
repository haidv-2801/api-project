using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Page
{
    public class PageModel
    {
        public class data
        {
            public string id { get; set; }
            public string access_token { get; set; }
            public string name { get; set; }
            public string category { get; set; }
            public string about { get; set; }
            public string link { get; set; }
        }


    
        [JsonProperty("data")]
        public List<data> datas { get; set; }


        public class paging
        {
            public class cursor
            {
                public string before { get; set; }
                public string after { get; set; }
            }
        }
    }
}