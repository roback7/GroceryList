﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroceryList.Repository;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    public class ListController : ApiController
    {
        // GET api/list/5
        public GList Get(int id)
        {
            GList list = new GList();
            Repository.Repository r = new Repository.Repository();
            list = r.getList(id);
            return list;
        }

        public Dictionary<int, string> Get() {
            Dictionary<int, string> customers = new Dictionary<int, string>();
            Repository.Repository r = new Repository.Repository();
            customers = r.getCustomers();
            return customers;
        }

        // PUT api/list/5
        public void Put(int id, string item)
        {
            Repository.Repository r = new Repository.Repository();
            r.addItem(id, item);
        }

        // POST api/list
        public void Post(int id, string name)
        {
            Repository.Repository r = new Repository.Repository();
            r.addCustomer(id, name);
        }

        // DELETE api/list/5
        public void Delete(int id, string item)
        {
            Repository.Repository r = new Repository.Repository();
            r.deleteItem(id, item);
        }
    }
}
