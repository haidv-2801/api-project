using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers.FbApiController
{
    public class CommentController : Controller
    {
        // GET: Group
        public ActionResult Index(string id)
        {
            string AccessToken = Session["Access_Token"] as string; 
            string PageId = ConfigurationManager.AppSettings["PageId"];
            string apiString = string.Concat(id, "/comments?access_token=" + AccessToken);
            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);

            CommentModel listGr = JsonConvert.DeserializeObject<CommentModel>(responseString);
            return View(listGr);
        }
    }
}