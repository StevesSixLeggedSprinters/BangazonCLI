using System;
using System.Collections.Generic;
using Bangazon.Models;


namespace Bangazon
{
    public class ProductManager
    {   //cust and prod act like Taco

        private List<Product> _productList = new List<Product>();
        private DatabaseInterface _db;

        public ProductManager

        //This method was authored by Jordan Dhaenens
        //Is creates a product line item in the database and returns the id response from the database
        public int AddProduct(double price, string title, string descript, DateTime prodAdded, int quant, int custID, int prodTypeId)
        {
           



            // Product prod = new Product()
            // {
            //     Price = price,
            //     Title = title,
            //     Description = descript,
            //     DateProductAdded = prodAdded,
            //     Quantity = quant,
            //     CustomerId = custID, 
            //     ProductTypeId = prodTypeId
            // };
            _productList.Add(prod);
            return 1;
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