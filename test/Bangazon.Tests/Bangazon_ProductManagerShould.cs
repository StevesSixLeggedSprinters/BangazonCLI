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
        
        /*Authored by Kyle Kellums and Krissy Caron 
        This Test Method needs the orderId(which contains access to the customerId)
        and takes the productId and adds that to the order for that customer. 
        This will return a new int of ProductOrderId*/
        [Fact]
        public void ShouldAddProductToCustomerOrder()
        {
            int orderId = 4;
            int productId = 7;

            var addedToCart = _something.AddProductToOrder(orderId, productId);
            Assert.True(addedToCart);
        }

        /* Authored by Kyle Kellums and Krissy Caron 
        This test is for the GetAllProducts method. It asserts that what is returned is a List type of all the products in the database.
        */
        [Fact]
        public void ShouldGetAllProductsAvailableInDatabase()
        {
            List<Product> listOfAllAvailableProducts = _something.GetAllProducts();
            Assert.IsType<List<Product>>(listOfAllAvailableProducts);
        }

    }
    
}
