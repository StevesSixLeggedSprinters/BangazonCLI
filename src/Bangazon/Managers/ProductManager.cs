using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{                
    //The class ProductManager holds all methods that interact with the Product table. Kevin Miller.
    public class ProductManager
    {             
        
        // The method AddProduct returns True.
        public bool AddProduct(Customer cust, Product prod)
        {
            return true;
        }
        
        //The method CreateProduct returns a string that is passed in. 
        public string CreateProduct(string aProduct)
        {
            return aProduct;
        }
    }
}