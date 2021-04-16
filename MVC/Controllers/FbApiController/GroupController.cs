using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC.Models;
using Newtonsoft.Json;
using System.Web.Http;


namespace MVC.Controllers.FbApiController
{
    public class GroupController : Controller
    {
        private readonly string appId = ConfigurationManager.AppSettings["AppId"];
        private readonly string access_token = ConfigurationManager.AppSettings["Access_Token"];
        // GET: Group
        public ActionResult Index()
        {
            string AccessToken = ConfigurationManager.AppSettings["Access_Token"];
            string PageId = ConfigurationManager.AppSettings["PageId"];
            string apiString = "me/groups?access_token=" + AccessToken;
            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            GroupModel listGr = JsonConvert.DeserializeObject<GroupModel>(responseString);
            return View(listGr);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Post()
        {
            string apiRequest = string.Concat("me/", "groups?");

            string response = GlobalVariables.GetStringResponse(apiRequest, "Get");
            GroupModel grModel = JsonConvert.DeserializeObject<GroupModel>(response);
            return View(grModel); 
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Post([FromBody] string post)
        {
            Post model = JsonConvert.DeserializeObject<Post>(post);
           
             
            foreach (var item in model.listGroupId)
            {
                string apiRequest = string.Concat(item, "/feed");
                apiRequest = String.Concat(apiRequest, "?message=", model.message);
                apiRequest = String.Concat(apiRequest, "&link=", model.link, "&");
                string response = GlobalVariables.GetStringResponse(apiRequest, "Post");
            }
           
           
            return View();
        }
    }
}