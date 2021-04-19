using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Configuration;
using MVC.Models;

namespace MVC.Controllers.FbApiController
{
    public class LoginController : Controller
    {

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url)
                {
                    Query = null,
                    Fragment = null,
                    Path = Url.Action("UserInfo")
                };
                return uriBuilder.Uri;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginWithFB()
        {
            var fb = new FacebookClient();

            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["AppId"],
                client_secret = ConfigurationManager.AppSettings["AppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult UserInfo(string code)
        {
            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["AppId"],
                client_secret = ConfigurationManager.AppSettings["AppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            
            var accessToken = result.access_token;
            Session["Access_Token"] = accessToken;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=id,name,birthday,email,gender,location,link,picture");


                User user = new User
                {
                    id = me.id,
                   name=me.name,
                   birthday=me.birthday,
                   email=me.email,
                   gender=me.gender,
                   address=me.location.name,
                   link=me.link,
                   picture=me.picture.data.url
                };

                Session["user_info"] = user;
                return View();
            }
            else
            {
                return Content("Some error occurred!");
            }
        }
    }
}