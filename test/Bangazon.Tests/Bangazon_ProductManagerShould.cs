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

        [Fact]
        public void AddCustomersProductToCustomersInventory()
        {
            Customer newCust = new Customer()
            {
                FirstName = "frst",
                LastName = "last",
                CustomerId = 1
            };

            Product newProd = new Product()
            {
                ProductId = 1,
                Price = 21000.99,
                Title = "Audi",
                Description = "Awesome Car",
                DateProductAdded = DateTime.Now,
                CustomerId = 1,
                Quantity = 9
            };


            var prodTest = _something.AddProduct(newCust, newProd);
            Assert.True(prodTest);


        }

        [Fact]
        public void CreateProductForCustomerToAdd()
        {
            string product = "Audi R8";
            var thisProd = _something.CreateProduct(product);
            Assert.Equal(thisProd, "Audi R8");

        }



    }
    
}
