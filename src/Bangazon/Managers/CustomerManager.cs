using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class CustomerManager
    {
        public static Customer ActiveCustomer { get; set; }
        private List<Customer> _customers = new List<Customer>();
        
        private DatabaseInterface _db;

        //This is the New Customer Manager Constructor
        public CustomerManager(DatabaseInterface db)
        {
            _db = db;

        }


        //This Method is creating a single customer, and is currently taking a string 
        //from the test enviroment and returning that string to pass.
        public int CreateCustomer(string firstName, string lastName, string email, string phone, DateTime dateAccountCreated)
        {
            _customers.Add(new Customer(){
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DateAccountCreated = dateAccountCreated
            });

            string sqlStatment = $"insert into Customer values (null,'{firstName}', '{lastName}', '{email}', '{phone}', {dateAccountCreated})";
            int customerId = _db.Insert(sqlStatment);
            return customerId;
        }

        //This method was authored by Jordan Dhaenens
        //This method serves to retrieve all customers, eventually
        public List<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}