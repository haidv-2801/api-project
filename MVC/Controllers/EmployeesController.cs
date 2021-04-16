using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Bai351_1_09042021;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(string searchString)
         {
            string ApiRequest = "Employees";
            if (!string.IsNullOrEmpty(searchString))
            {
                ApiRequest = string.Concat(ApiRequest, "?name=", searchString);
            }
            string method = "Get";
            string dataResponse = GlobalVariables.GetStringResponse(ApiRequest, method);
            IEnumerable<tblNhanvien> empList = new JavaScriptSerializer().Deserialize<List<tblNhanvien>>(dataResponse);
            return View(empList);
        }

  
        public ActionResult Delete(long id)
        {
            
            string ApiRequest = "Employees/" + id.ToString();
            string method = "Delete";
            string dataResponse = GlobalVariables.GetStringResponse(ApiRequest, method);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            string ApiRequest = "Employees/" + id.ToString();
            string method = "Get";
            string dataResponse = GlobalVariables.GetStringResponse(ApiRequest, method);
            tblNhanvien emp = new JavaScriptSerializer().Deserialize<tblNhanvien>(dataResponse);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(tblNhanvien emp)
        {
            string ApiRequest = "Employees?";
            ApiRequest = string.Concat(ApiRequest, "id=", emp.Manhanvien);
            ApiRequest = string.Concat(ApiRequest, "&name=", emp.Tennhanvien);
            ApiRequest = string.Concat(ApiRequest, "&birthday=", emp.Ngaysinh);
            ApiRequest = string.Concat(ApiRequest, "&gender=", emp.Gioitinh);
            ApiRequest = string.Concat(ApiRequest, "&address=", emp.Diachi);
            ApiRequest = string.Concat(ApiRequest, "&phoneNumber=", emp.Dienthoai);

            string method = "Put";
            string dataResponse = GlobalVariables.GetStringResponse(ApiRequest, method);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblNhanvien emp)
        {
            string ApiRequest = "Employees?";
            ApiRequest = string.Concat(ApiRequest, "&name=", emp.Tennhanvien);
            ApiRequest = string.Concat(ApiRequest, "&birthday=", emp.Ngaysinh);
            ApiRequest = string.Concat(ApiRequest, "&gender=", emp.Gioitinh);
            ApiRequest = string.Concat(ApiRequest, "&address=", emp.Diachi);
            ApiRequest = string.Concat(ApiRequest, "&phoneNumber=", emp.Dienthoai);
            string method = "Post";
            string dataResponse = GlobalVariables.GetStringResponse(ApiRequest, method);
            return RedirectToAction("Index");
        }

    }
}