using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class CustomerManager
    {
        //This field authored by Jordan Dhaenens
        public static Customer ActiveCustomer { get; set; }
        private List<Customer> _customers = new List<Customer>();
        
        /*Created by Krissy Caron 
        This is creating a new private variable db from the DatabaseInterface */ 
        private DatabaseInterface _db;
        /* Created by Krissy Caron 
        The New Customer Manager Constructor creates a new db */
        public CustomerManager(DatabaseInterface db)
        {
            _db = db;
            ActiveCustomer = new Customer()
            {
                CustomerId = 0
            };

        }


        /*Authored by Krissy Caron This Method is inserting a single customer, passing in the customer object, 
        returning the customerId from the Customer Table created in the enviroment variable currently. */
        public int CreateCustomer(string firstName, string lastName, string email, string phone, DateTime dateAccountCreated)
        {
            _customers.Add(new Customer(){
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DateAccountCreated = dateAccountCreated
            });

            string sqlStatment = $"insert into Customer values (null,'{firstName}', '{lastName}', '{email}', '{phone}', '{dateAccountCreated}')";
            int customerId = _db.Insert(sqlStatment);
            return customerId;
        }

        //This method was authored by Jordan Dhaenens
        //This method serves to retrieve all customers, eventually
        /*This Method ammended by Krissy Caron:
        Includes the query to return all customers currently in the database */
        public List<Customer> GetCustomers()
        {
            _db.Query("select CustomerId, FirstName, LastName, Email, Phone, DateAccountCreated from Customer", 
                (SqliteDataReader reader) => {
                    _customers.Clear();
                    while (reader.Read())
                    {
                        _customers.Add(new Customer()
                        {
                            CustomerId = reader.GetInt32(0),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            Email = reader[3].ToString(),
                            Phone = reader[4].ToString(),
                            DateAccountCreated = reader.GetDateTime(5)
                        });
                    }
                });
            return _customers;
        }
        /*Added by Krissy Caron
        This Linq Statement takes the int of customerId and returns the entire customer ojected related to that id. 
        Allowing access to that specific "Chosen Customer"
        */
        public Customer GetCustomer (int customerId) => _customers.SingleOrDefault(Customer=> Customer.CustomerId == customerId);
    }
}