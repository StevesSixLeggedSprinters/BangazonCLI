using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class ProductManager
    {   //cust and prod act like Taco

        private List<Product> _productList = new List<Product>();

        public bool AddProduct(Customer cust, Product prod)
        {
            return true;
        }

        
        public string CreateProduct(string aProduct)
        {
            return aProduct;
        }
        
        /* Authored by Kyle Kellums and Krissy Caron 
        This AddProductToOrder method returns a boolean for the test. orderId and productId are passed in to the method. 
        It will need to be refactored to an int type to return the ProductOrderId.  
        */
        public bool AddProductToOrder(int orderId, int productId)
        {
            //This will return the ProductOrderId
            return true;
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