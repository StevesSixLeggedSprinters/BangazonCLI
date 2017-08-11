using System;
using System.Collections.Generic;
using Bangazon.Models;


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

        /* Authored by Kyle Kellums and Krissy Caron 
        This GetAllProducts method gets a list of all products in the database/invetory. It is a List type, and the method returns a list of the products.
        */
        public List<Product> GetAllProducts()
        {
            return _productList;
        }

    }
}