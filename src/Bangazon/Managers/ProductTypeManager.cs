using System;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon
{
    public class ProductTypeManager
    {
        private List<ProductType> _types = new List<ProductType>();

        public void AddProductType(ProductType type)
        {
            _types.Add(type);
        }
        public List<ProductType> GetProductTypes()
        {
            return _types;
        }
    }
}