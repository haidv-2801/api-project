using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai351_1_09042021.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<tblSanpham> ListAll()
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblSanphams.ToList();
        }

        [HttpGet]
        public List<tblSanpham> ListById(string id)
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblSanphams.Where(x => x.Id.ToLower().Contains(id.ToLower())).ToList();
        }

        [HttpGet]
        public List<tblSanpham> ListByName(string name)
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblSanphams.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        [HttpGet]
        public List<tblSanpham> ListTonkho()
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            return db.tblSanphams.Where(x => x.Amount > 0).ToList();
        }

        [HttpPost]
        public bool AddProduct(string id, string name, string description, decimal buyPrice, decimal price, int amount)
        {

            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();

                tblSanpham prod = db.tblSanphams.FirstOrDefault(x => x.Id == id);
                if (prod != null)
                {
                    return false;
                }

                prod = new tblSanpham
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    BuyPrice = buyPrice,
                    Price = price,
                    Amount = amount
                };

                db.tblSanphams.InsertOnSubmit(prod);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public bool UpdateProduct(string id, string name, string description, decimal buyPrice, decimal price, int amount)
        {

            try
            {
                DbCustomersDataContext db = new DbCustomersDataContext();

                tblSanpham prod = db.tblSanphams.FirstOrDefault(x => x.Id == id);
                if (prod == null)
                {
                    return false;
                }

                prod.Name = name;
                prod.Description = description;
                prod.BuyPrice = buyPrice;
                prod.Price = price;
                prod.Amount = amount;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool Delete(string id)
        {
            DbCustomersDataContext db = new DbCustomersDataContext();
            tblSanpham prod = db.tblSanphams.FirstOrDefault(x => x.Id == id);
            if (prod == null) return false;

            db.tblSanphams.DeleteOnSubmit(prod);
            db.SubmitChanges();
            return true;
        }
    }
}
