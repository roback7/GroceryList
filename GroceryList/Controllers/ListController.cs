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
    public class ListController : ApiController
    {
        /// <summary>
        /// Retrieves grocery list for the given Customer ID.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Grocery List</returns>
        public IHttpActionResult Get(int id)
        {
            GList list = new GList();
            Repository.Repository r = new Repository.Repository();
            try
            {
                list = r.getList(id);
            }
            catch (Exception e) {
                return BadRequest(e.ToString());
            }

            //No Content
            if (list.groceryList.Count < 1) {
                return Ok();
            }
            return Ok(list);
        }

        /// <summary>
        /// Retrieves all Customers and their Customer ID.
        /// </summary>
        /// <returns>Customers with their Customer IDs.</returns>
        public IHttpActionResult Get() {
            Dictionary<int, string> customers = new Dictionary<int, string>();
            Repository.Repository r = new Repository.Repository();
            try
            {
                customers = r.getCustomers();
            }
            catch (Exception e) {
                return BadRequest(e.ToString());
            }
            //No Content
            if (customers.Count < 1)
            {
                return Ok();
            }

            return Ok(customers);
        }

        /// <summary>
        /// Places an item in a customers grocery list.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <param name="item">Item</param>
        public IHttpActionResult Put(int id, string item)
        {
            Repository.Repository r = new Repository.Repository();
            try
            {
                r.addItem(id, item);
            } catch (Exception e) {
                return BadRequest(e.ToString());
            }
            return Ok();
        }

        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <param name="name">Customer Name</param>
        /// <returns></returns>
        public IHttpActionResult Post(int id, string name)
        {
            Repository.Repository r = new Repository.Repository();
            try
            {
                r.addCustomer(id, name);
            } catch (Exception e) {
                return BadRequest(e.ToString());
            }
            return Ok();
        }

        /// <summary>
        /// Deletes an item from a Customer's grocery list.
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <param name="item">Item</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id, string item)
        {
            Repository.Repository r = new Repository.Repository();
            try {
                r.deleteItem(id, item);
            } catch (Exception e) {
                return BadRequest(e.ToString());
            }
            return Ok();
        }
    }
}
