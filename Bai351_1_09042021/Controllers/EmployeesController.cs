using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Bai351_1_09042021.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public List<tblNhanvien> getAllEmployees()
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblNhanviens.ToList();
        }

        [HttpGet]
        public tblNhanvien getEmployee(long id)
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblNhanviens.FirstOrDefault(x => x.Manhanvien == id);
        }

        [HttpPost]
        public bool InsertEmployee(string name, DateTime birthday, bool gender, string address, string phoneNumber)
        {
            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();

                tblNhanvien emp = new tblNhanvien();
                emp.Tennhanvien = name;
                emp.Ngaysinh = birthday;
                emp.Gioitinh = gender;
                emp.Diachi = address;
                emp.Dienthoai = phoneNumber;
                db.tblNhanviens.InsertOnSubmit(emp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                string t = e.Message;
                return false;
            }
        }


        [HttpPut]
        public bool UpdateEmployee(tblNhanvien entity)
        {
            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();

                var emp = db.tblNhanviens.FirstOrDefault(x => x.Manhanvien == entity.Manhanvien);
                if (emp == null)
                {
                    return false;
                }
                emp.Tennhanvien = entity.Tennhanvien;
                emp.Ngaysinh = entity.Ngaysinh;
                emp.Gioitinh = entity.Gioitinh;
                emp.Diachi = entity.Diachi;
                emp.Dienthoai = entity.Dienthoai;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        public bool UpdateEmployee(long id, string name, DateTime birthday, bool gender, string address, string phoneNumber)
        {
            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();
               
                var emp = db.tblNhanviens.FirstOrDefault(x => x.Manhanvien == id);
                if (emp == null)
                {
                    return false;
                }
                emp.Tennhanvien = name;
                emp.Ngaysinh = birthday;
                emp.Gioitinh = gender;
                emp.Diachi = address;
                emp.Dienthoai = phoneNumber;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteEmployee(long id)
        {
            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();
                var emp = db.tblNhanviens.FirstOrDefault(x => x.Manhanvien == id);
                if (emp == null) return false;
                db.tblNhanviens.DeleteOnSubmit(emp);
                db.SubmitChanges();
                return true;
            }
            catch 
            {
                return false;
            }
           
        }

        [HttpGet]
        public List<tblNhanvien> findEmployee(string name)
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            IQueryable<tblNhanvien> filterList = db.tblNhanviens;
            if (!string.IsNullOrEmpty(name))
            {
                filterList = filterList.Where(x => x.Tennhanvien.ToLower().Contains(name.ToLower()));
            }
            return filterList.ToList();
        }
    }
}
