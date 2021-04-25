using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ShareModel
    {
        [JsonProperty("count")]
        public string count { get; set; }
    }
}