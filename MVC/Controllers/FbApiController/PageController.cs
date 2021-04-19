using MVC.Models;
using MVC.Models.Page;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers.FbApiController
{
    public class PageController : Controller
    {
     
        public ActionResult Index(string id)
        {
            string AccessToken = Session["Access_Token"] as string;
            string apiString = "/accounts?fields=id,access_token,name,category,about,link&access_token=" + AccessToken;
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            PageModel listPage = JsonConvert.DeserializeObject<PageModel>(responseString);
            return View(listPage);
        }

        public ActionResult Feed(string id, string AccessToken)
        {
           
            string apiString = "/feed?fields=id,message,created_time,from,full_picture&access_token=" + AccessToken;
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);



            PageFeedsModel listPage = JsonConvert.DeserializeObject<PageFeedsModel>(responseString);
            return View(listPage);
        }
    }
}