using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    /// <summary>
    /// Represents a customer's grocery list.
    /// </summary>
    public class GList
    {
        /// <summary>
        /// Name of the customer
        /// </summary>
        public string customerName { get; set; }

        /// <summary>
        /// Unique Customer ID
        /// </summary>
        public int customerID { get; set; }

        /// <summary>
        /// List of items on the grocery list
        /// </summary>
        public List<string> groceryList { get; set; }
    }
}
