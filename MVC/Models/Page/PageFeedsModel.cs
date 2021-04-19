using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PageFeedsModel
    {
        public class data
        {
            public string id { get; set; }
            public string message { get; set; }
            public string created_time { get; set; }
         
            public From from { get; set; }
            public string full_picture { get; set; }
        }

        [JsonProperty("data")]
        public List<data> datas { get; set; }
       
        public class paging
        {
            public class cursors
            {
                public string previous { get; set; }
                public string next { get; set; }
            }
        }

        public class From
        {
            public string name { get; set; }
            public string id { get; set; }
        }
    }
}