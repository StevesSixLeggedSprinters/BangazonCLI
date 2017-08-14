using System;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class ProductTypeManager
    {
        private List<ProductType> _types = new List<ProductType>();
        private DatabaseInterface _db;
        public ProductTypeManager(DatabaseInterface db)
        {
            _db = db;
        }

        public void AddProductType(ProductType type)
        {
            _types.Add(type);
        }

        //This method is authored by Jordan Dhaenens
        //This method will grab all productTypes from the database, put them into a list, and return the list to the caller
        public List<ProductType> GetProductTypes()
        {
            //SQL query command
            string command = $"select * from productType";
            //ActionHandler for _db.Query()
            Action<SqliteDataReader> action = (SqliteDataReader reader) => {
                _types.Clear();
                while ( reader.Read() )
                {
                    _types.Add( new ProductType() 
                    {
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader[1].ToString()
                    });
                }
            };
            //Query the database
            _db.Query(command, action);
            //Return list of productTypes
            return _types;
        }
    }
}