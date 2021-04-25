using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CommentModel
    {

        [JsonProperty("data")]
        public List<data> datas { get; set; }

        public class data
        {
            public string created_time { get; set; }
            public from from { get; set; }
            public string message { get; set; }
            public string id { get; set; }
        }
        [JsonProperty("summary")]
        public summary Summary { get; set; }
        public class from
        {
            public string name { get; set; }
            public string id { get; set; }
        }
        public class summary
        {
            public int total_count { get; set; }

        }
        public class paging
        {
            public class cursors
            {
                public string before { get; set; }
                public string after { get; set; }
            }
        }
    }
}