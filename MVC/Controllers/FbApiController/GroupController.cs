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
        // GET: Group
        public ActionResult Index(string id)
        {
            string AccessToken = ConfigurationManager.AppSettings["Access_Token"];
            string apiString = "/groups?access_token=" + AccessToken;
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            GroupModel listGr = JsonConvert.DeserializeObject<GroupModel>(responseString);
            return View(listGr);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Post()
        {
            string AccessToken = ConfigurationManager.AppSettings["Access_Token"];
            string apiString = "/groups?access_token=" + AccessToken;
            apiString = string.Concat("1413994845619966", apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            GroupModel listGr = JsonConvert.DeserializeObject<GroupModel>(responseString);
            return View(listGr); 
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Post([FromBody] string post)
        {
            string access_token = ConfigurationManager.AppSettings["Access_Token"];
            Post model = JsonConvert.DeserializeObject<Post>(post);
            foreach (var item in model.listGroupId)
            {
                string apiRequest = string.Concat(item, "/feed");
                apiRequest = String.Concat(apiRequest, "?message=", model.message);
                apiRequest = String.Concat(apiRequest, "&link=", model.link, "&access_token=", access_token);
                GlobalVariables.GetStringResponse(apiRequest, "Post");
            }
            return Content("Posting group completely!");
        }
    }
}