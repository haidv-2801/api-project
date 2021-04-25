using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC.Models;
using Newtonsoft.Json;
using System.Web.Http;
using MVC.Models.Group;

namespace MVC.Controllers.FbApiController
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index(string id)
        {
            string AccessToken = Session["Access_Token"] as string;
            string apiString = "/groups?fields=id,name,privacy,member_count&access_token=" + AccessToken;
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            GroupModel listGr = JsonConvert.DeserializeObject<GroupModel>(responseString);
            return View(listGr);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Feed(string id)
        {
            string AccessToken = Session["Access_Token"] as string;

            string apiString = "/feed?fields=id,message,caption,created_time,from,full_picture,link,comments.summary(true),shares&access_token=" + AccessToken;//bo reactions
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            FeedsModel listGr = JsonConvert.DeserializeObject<FeedsModel>(responseString);
            return View(listGr); 
        }

        public ActionResult Post()
        {
            string AccessToken = Session["Access_Token"] as string;
            string id = (Session["user_info"] as User).id;

            string apiString = "/groups?fields=id,name,privacy&access_token=" + AccessToken;
            apiString = string.Concat(id, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            GroupModel listGr = JsonConvert.DeserializeObject<GroupModel>(responseString);
            return View(listGr);
        }

         [System.Web.Mvc.HttpPost]
         public JsonResult Post([FromBody] string post)
         {
            try
            {
                string access_token = Session["Access_Token"] as string;
                Post model = JsonConvert.DeserializeObject<Post>(post);
                foreach (var item in model.listGroupId)
                {
                    string apiRequest = string.Concat(item, "/feed");
                    apiRequest = String.Concat(apiRequest, "?message=", model.message);
                    apiRequest = String.Concat(apiRequest, "&link=", model.link, "&access_token=", access_token);
                    GlobalVariables.GetStringResponse(apiRequest, "Post");
                }
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
           
         }


    }
}