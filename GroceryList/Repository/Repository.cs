﻿using System;
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
            GList groceryList = new GList();
            groceryList.groceryList = new List<string>();

            SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;

            cmd.Parameters.Add("customerID", DbType.Int32);
            cmd.Parameters["customerID"].Value = customerID;
            cmd.CommandText = "SELECT * FROM LIST, CUSTOMER WHERE LIST.customerID = @customerID AND CUSTOMER.customerID = LIST.customerID";

            using (SQLiteDataReader read = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(read);

                foreach (DataRow row in dt.Rows)
                {
                    groceryList.groceryList.Add(Convert.ToString(row["ITEM"]));
                    groceryList.customerName = Convert.ToString(row["NAME"]);
                }

                read.Close();
            }
            groceryList.customerID = customerID;
            return groceryList;
        }

        public GList addItem(int customerID, string item) {
            GList groceryList = new GList();
            return groceryList;
        }
    }
}
