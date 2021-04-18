using BlogApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string dataResponse = GlobalVariables.JsonResponse("Post", "Get");
            List<post> items = JsonConvert.DeserializeObject<List<post>>(dataResponse);
            return View(items);
        }

        public ActionResult PostDetail(long id)
        {
            string dataResponse = GlobalVariables.JsonResponse("Post?id=" + id.ToString(), "Get");
            post item = JsonConvert.DeserializeObject<post>(dataResponse);
            return View(item);
        }
    }
}