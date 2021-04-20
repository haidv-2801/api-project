using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Page
{
    public class Comment
    {
        public class datas
        {

        }
        
        public class summarys
        {
            public string order { get; set; }
            public string total_count { get; set; }
            public string can_comment { get; set; }
        }

        public List<datas> data { get; set; }
        public summarys summary { get; set; }

    }
}