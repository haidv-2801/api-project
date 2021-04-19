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
    public class PostController : Controller
    {
        // GET: Post
   
        public ActionResult getRecentPosts(string userId, int takeNum = 100)
        {
            string AccessToken = Session["Access_Token"] as string;
            string apiString = string.Concat(userId, "/posts?access_token=", AccessToken);
            string method = "Get";
            string responseString = GlobalVariables.GetStringResponse(apiString, method);
            FeedsModel feeds = JsonConvert.DeserializeObject<FeedsModel>(responseString);

            List<PostDetail> listPostDetal = new List<PostDetail>();

            foreach(var item in feeds.datas)
            {
                string apiString1 = string.Concat(item.id, "?fields=id,message,link,full_picture,created_time&access_token=", AccessToken);
                string responseString1 = GlobalVariables.GetStringResponse(apiString1, method);
                PostDetail postDetail = JsonConvert.DeserializeObject<PostDetail>(responseString1);
                listPostDetal.Add(postDetail);
            }

            IEnumerable<PostDetail> takeList = listPostDetal.Take(takeNum);
            return PartialView("posts", takeList.ToList());
        }
    }
}