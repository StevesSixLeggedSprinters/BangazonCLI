using System;
using System.Collections.Generic;
using Bangazon.Models;
using Microsoft.Data.Sqlite;


namespace Bangazon
{
    public class ProductManager
    {   //cust and prod act like Taco

        private List<Product> _productList = new List<Product>();
        private DatabaseInterface _db;

        public ProductManager(DatabaseInterface db) 
        {
            _db = db;
        }

        //This method was authored by Jordan Dhaenens
        //This method creates a product line item in the database and returns the id response from the database
        public int AddProduct(double price, string title, string descript, DateTime prodAdded, int quant, int custID, int prodTypeId)
        {
           string command = $"insert into product values (null, '{price}', '{title}', '{descript}', '{prodAdded}', '{quant}', '{custID}', '{prodTypeId}')";
           int productId = _db.Insert(command);

           return productId;
        }

        //This method was authored by Jordan Dhaenens
        //This method grabs all products from database, adds them to a list and returns them to the caller
        public List<Product> GetAllProducts()
        {
            //SQL query command
            string command = $"select * from product";
            //ActionHandler for _db.Query()
            Action<SqliteDataReader> action = (SqliteDataReader reader) => {
                _productList.Clear();
                while ( reader.Read() )
                {
                    _productList.Add( new Product() 
                    {
                        ProductId = reader.GetInt32(0),
                        Price = reader.GetDouble(1),
                        Title = reader[2].ToString(),
                        Description = reader[3].ToString(),
                        DateProductAdded = reader.GetDateTime(4),
                        Quantity = reader.GetInt32(5),
                        CustomerId = reader.GetInt32(6),
                        ProductTypeId = reader.GetInt32(7)
                    });
                }
            };
            //Query the database
            _db.Query(command, action);
            //Return list of productTypes
            return _productList;
        }

    }
}