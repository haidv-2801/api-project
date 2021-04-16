using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bai351_1_09042021.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public List<tblKhach> GetCustomerLists()
        {
            DbCustomersDataContext dbCustomer = new DbCustomersDataContext();
            return dbCustomer.tblKhaches.ToList();
        }


        [HttpGet]
        public tblKhach GetCustomer(long id)
        {
            DbCustomersDataContext dbCustomer = new DbCustomersDataContext();
            return dbCustomer.tblKhaches.FirstOrDefault(x => x.Makhach == id);
        }

        [HttpPost]
        public bool InsertNewCustomer(long id, string name, string address, string phoneNumber)
        {
            try
            {
                DbCustomersDataContext dbCustomer = new DbCustomersDataContext();
                tblKhach cus = new tblKhach();
                cus.Makhach = id;
                cus.Tenkhach = name;
                cus.Diachi = address;
                cus.Dienthoai = phoneNumber;

                dbCustomer.tblKhaches.InsertOnSubmit(cus);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                string t = e.Message;
                return false;
            }
        }

        [HttpPut]
        public bool UpdateCustomer(long id, string name, string address, string phoneNumber)
        {
            try
            {
                DbCustomersDataContext dbCustomer = new DbCustomersDataContext();
                tblKhach cus = dbCustomer.tblKhaches.FirstOrDefault(x => x.Makhach == id);
                if (cus == null) return false;

                cus.Tenkhach = name;
                cus.Diachi = address;
                cus.Dienthoai = phoneNumber;

        
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteCustomer(long id)
        {
            try
            {
                DbCustomersDataContext dbCustomer = new DbCustomersDataContext();
                tblKhach cus = dbCustomer.tblKhaches.FirstOrDefault(x => x.Makhach == id);
                if (cus == null) return false;
                dbCustomer.tblKhaches.DeleteOnSubmit(cus);
                dbCustomer.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
