using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryList.Models;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace GroceryList.Repository
{
    public class Repository
    {
        public Repository() { }

        /// <summary>
        /// Retrieve grocery list for the given customer from database.
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <returns>GList</returns>
        public GList getList(int customerID) {
            GList list = new GList();
            list.groceryList = new List<string>();

            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.Parameters.Add("customerID", DbType.Int32);
            cmd.Parameters["customerID"].Value = customerID;
            cmd.CommandText = "SELECT * FROM LIST, CUSTOMER WHERE CUSTOMER.customerID = @customerID AND CUSTOMER.customerID = LIST.customerID";

            using (SQLiteDataReader read = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(read);

                foreach (DataRow row in dt.Rows)
                {
                    list.groceryList.Add(Convert.ToString(row["ITEM"]));
                    list.customerName = Convert.ToString(row["NAME"]);
                }

                read.Close();
            }
            list.customerID = customerID;
            return list;
        }

        /// <summary>
        /// Retrieve a dictionary pairing each customer with their customer ID.
        /// </summary>
        /// <returns>Dictionary(int, string)</returns>
        public Dictionary<int, string> getCustomers()
        {
            Dictionary<int, string> customers = new Dictionary<int, string>();

            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM CUSTOMER";

            using (SQLiteDataReader read = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(read);

                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(Convert.ToInt32(row["customerID"]), Convert.ToString(row["NAME"]));
                }

                read.Close();
            }
            return customers;
        }

        /// <summary>
        /// Adds a grocery item to the given customer's list.
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="item">Item</param>
        public void addItem(int customerID, string item) {

            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.Parameters.Add("customerID", DbType.Int32);
            cmd.Parameters.Add("item", DbType.String);
            cmd.Parameters["customerID"].Value = customerID;
            cmd.Parameters["item"].Value = item;
            cmd.CommandText = "INSERT INTO LIST VALUES(@item, @customerID)";

            SQLiteDataReader read = cmd.ExecuteReader();
            read.Close();
            connection.Close();
        }

        /// <summary>
        /// Deletes an item from the given customer's list.
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="item">List</param>
        public void deleteItem(int customerID, string item)
        {

            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.Parameters.Add("customerID", DbType.Int32);
            cmd.Parameters.Add("item", DbType.String);
            cmd.Parameters["customerID"].Value = customerID;
            cmd.Parameters["item"].Value = item;
            cmd.CommandText = "DELETE FROM LIST WHERE item = @item AND customerID = @customerID";

            SQLiteDataReader read = cmd.ExecuteReader();
            read.Close();
            connection.Close();
        }

        /// <summary>
        /// Adds a customer to the database.
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="name">Customer Name</param>
        public void addCustomer(int customerID, string name) {
            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.Parameters.Add("customerID", DbType.Int32);
            cmd.Parameters.Add("name", DbType.String);
            cmd.Parameters["customerID"].Value = customerID;
            cmd.Parameters["name"].Value = name;
            cmd.CommandText = "INSERT INTO CUSTOMER VALUES(@customerID, @name)";

            SQLiteDataReader read = cmd.ExecuteReader();
            read.Close();
            connection.Close();
        }
    }
}
