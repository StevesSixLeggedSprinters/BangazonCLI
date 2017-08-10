using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class ProductTypeManagerShould
    {
        private ProductTypeManager _ProductTypeManager;
        public ProductTypeManagerShould()
        {
            _ProductTypeManager = new ProductTypeManager();
        }

        //This test is authored by Jordan Dhaenens
        //This test checks that productTypes are returned
        [Fact]
        public void GetAllProductTypesThatExist()
        {
            List<ProductType> typesList = _ProductTypeManager.GetProductTypes();
            Assert.Empty(typesList);

            ProductType type = new ProductType()
                {
                    ProductTypeId = 1,
                    Name = "shoe"
                };

            _ProductTypeManager.AddProductType(type);
            typesList = _ProductTypeManager.GetProductTypes();
            Assert.NotEmpty(typesList);
        } 

    }
}