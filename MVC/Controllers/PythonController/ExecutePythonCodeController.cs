using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronPython.Hosting;

namespace MVC.Controllers.PythonController
{
    public class ExecutePythonCodeController : Controller
    {
        // GET: ExecutePythonCode
        public ActionResult Index()
        {
            return View();
        }
    }
}