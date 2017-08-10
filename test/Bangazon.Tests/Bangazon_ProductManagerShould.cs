using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class ProductManagerShould
    {
        private ProductManager _something;
        public ProductManagerShould(){
            _something = new ProductManager();            
        }

        //This test was authored by Jordan Dhaenens
        //It checks that a product can be added to a seller's inventory
        [Fact]
        public void AddCustomersProductToCustomersInventory()
        {
    
            double Price = 21000.99;
            string Title = "Audi";
            string Description = "Awesome Car";
            DateTime DateProductAdded = DateTime.Now;
            int CustomerId = 1;
            int Quantity = 9;
            int ProductTypeId = 1;
        

            var prodTest = _something.AddProduct(Price, Title, Description, DateProductAdded, Quantity, CustomerId, ProductTypeId);
            Assert.NotNull(prodTest);
        }

        //Refactored by Jordan Dhaenens
        /* Authored by Kyle Kellums and Krissy Caron 
        This test is for the GetAllProducts method. It asserts that what is returned is a List type of all the products in the database.
        */
        [Fact]
        public void ShouldGetAllProductsAvailableInDatabase()
        {
            List<Product> listOfAllAvailableProducts = _something.GetAllProducts();
            Assert.Empty(listOfAllAvailableProducts);

            double Price = 21000.99;
            string Title = "Audi";
            string Description = "Awesome Car";
            DateTime DateProductAdded = DateTime.Now;
            int CustomerId = 1;
            int Quantity = 9;
            int ProductTypeId = 1;
        
            var prodTest = _something.AddProduct(Price, Title, Description, DateProductAdded, Quantity, CustomerId, ProductTypeId);
            listOfAllAvailableProducts = _something.GetAllProducts();
            Assert.NotEmpty(listOfAllAvailableProducts);
        }

    }
    
}
