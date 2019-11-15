using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class GList
    {
        public string customerName { get; set; }
        public int customerID { get; set; }
        public List<string> groceryList { get; set; }
    }
}
