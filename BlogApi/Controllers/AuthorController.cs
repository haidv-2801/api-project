using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class AuthorController : ApiController
    {
        public author GetAuthor(long id)
        {
            BlogDbContextDataContext db = new BlogDbContextDataContext();
            return db.authors.FirstOrDefault(x => x.ID == id);
        }
    }
}
