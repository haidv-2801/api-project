using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        public List<post> ListAll()
        {
            BlogDbContextDataContext db = new BlogDbContextDataContext();
            return db.posts.ToList();
        }

        [HttpGet]
        public post Detail(long id)
        {
            BlogDbContextDataContext db = new BlogDbContextDataContext();
            return db.posts.FirstOrDefault(x => x.ID == id);
        }

        [HttpPost]
        public bool Add()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
