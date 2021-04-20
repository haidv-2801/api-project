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

        [HttpGet]
        public ActionResult Post()
        {
            string AccessToken = Session["Access_Token"] as string;
            string UserId = (Session["user_info"] as User).id;

            string apiString = "/accounts?fields=id,access_token,name,category,about,link&access_token=" + AccessToken;
            apiString = string.Concat(UserId, apiString);

            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            PageModel listPage = JsonConvert.DeserializeObject<PageModel>(responseString);
            return View(listPage); 
        }


        [HttpPost]
        public JsonResult Post(string data)
        {

            try
            { 
                PagePostModel model = JsonConvert.DeserializeObject<PagePostModel>(data);

                foreach (var item in model.listGroupId)
                {
                    string apiRequest = string.Concat(item.id, "/feed");
                    apiRequest = String.Concat(apiRequest, "?message=", model.message);
                    apiRequest = String.Concat(apiRequest, "&published=", model.isPublished);
                    apiRequest = String.Concat(apiRequest, "&link=", model.link, "&access_token=", item.access_token);
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