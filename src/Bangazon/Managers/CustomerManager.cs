using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class CustomerManager
    {
        public static Customer ActiveCustomer { get; set; }

        private List<Customer> _customers = new List<Customer>(); 

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
            return 1;
        }

        //This method was authored by Jordan Dhaenens
        //This method serves to retrieve all customers, eventually
        public List<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}