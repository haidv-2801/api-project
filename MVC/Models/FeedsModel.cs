using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class FeedsModel
    {
        public class data
        {
            public string created_time { get; set; }
            public string message { get; set; }
            public string id { get; set; }
        }

        [JsonProperty("data")]
        public List<data> datas { get; set; }
       
        public class paging
        {
            public string previous { get; set; }
            public string next { get; set; }
        }
    }
}