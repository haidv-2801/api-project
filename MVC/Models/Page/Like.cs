using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Page
{
    public class Like
    {
        public class datas
        {

        }
        public class page
        {
            public class cursor
            {
                public string before { get; set; }
                public string after { get; set; }
            }
        }

        public class summarys
        {
            public string total_count { get; set; }
            public string can_like { get; set; }
            public string has_liked { get; set; }
        }

        public List<datas> data { get; set; }
        public page paging { get; set; }
        public summarys summary { get; set; }


    }
}