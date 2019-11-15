using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroceryList.Repository;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        public GList Get(int id)
        {
            GList list = new GList();
            Repository.Repository r = new Repository.Repository();
            list = r.getList(id);
            return list;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
