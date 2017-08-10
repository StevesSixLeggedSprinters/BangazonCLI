using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using Bangazon.Models;
using Bangazon;

namespace Bangazon.Data
{
    //This class serves to populate every table in the database with a few items
    public class DBPopulator
    {
        private SqliteConnection _connection;
        private List<Customer> _customers = new List<Customer>();

        //This method was authored by Jordan Dhaenens
        //This method serves to perform the actual population of the database
        public void Populate()
        {
            _connection = DBInterface.Connection;

            //Populating Customer table
            _connection.Insert( $"insert into customer values (null, 'Joe', 'Schmoe', 'something@something.com', '615-555-5555', 1)" );
            _connection.Insert( $"insert into customer values (null, 'Jill', 'Schmoe', 'something@something.com', '615-444-5555', 1)");
            _connection.Insert( $"insert into customer values (null, 'Juble', 'Lee', 'something@something.com', '615-333-5555', 1)");

            //Populating the ProductType table
            _connection.Insert( $"insert into ProductType values (null, 'Produce')");
            _connection.Insert( $"insert into ProductType values (null, 'Building Materials')");
            _connection.Insert( $"insert into ProductType values (null, 'Kitchen Goods')");


            //Populating the Product table
            _connection.Insert( $"insert into product values (null, 12.23, 'Vegetable Knife', 'This knife slices through veggies with ease. Great for salad prep!', '2017-04-12', 1, 2, 3)");
            _connection.Insert( $"insert into product values (null, 12.24, 'Meat Knife', 'This knife slices through meat with ease. Great for salad prep!', '2017-04-12', 1, 2, 3)");
            _connection.Insert( $"insert into product values (null, 12.25, 'Bath Tiles', '', '2017-04-12', 1, 2, 1)");
            


            //Populating the PaymentType table
            _connection.Insert( $"insert into PaymentType values (null, 'Visa', 1234567891234567, 1)");
            _connection.Insert( $"insert into PaymentType values (null, 'Visa', 1234567891234567, 2)");
            _connection.Insert( $"insert into PaymentType values (null, 'Visa', 1234567891234567, 3)");

        }

        
    }
}