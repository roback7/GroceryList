using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GroceryList.Models;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace GroceryList.Repository
{
    public class Repository
    {
        public Repository() { }

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
