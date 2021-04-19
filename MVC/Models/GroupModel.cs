using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class GroupModel
    {
        public class data
        {
            public string id { get; set; }
            public string name { get; set; }
            public string privacy { get; set; }
            public string member_count { get; set; }
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
            public string next { get; set; }
            public string previous { get; set; }
        }
    }
}