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

        [Fact]
        public void GetAllProductTypesThatExist()
        {
            List<ProductType> typesList = _ProductTypeManager.GetProductTypes();
            Assert.IsType<List<ProductType>>(typesList);
        } 

    }
}