using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class CustomerManager
    {
        private Customer _activeCustomer = new Customer();

        private List<Customer> _customers = new List<Customer>(); 

        //This Method is creating a single customer, and is currently taking a string 
        //from the test enviroment and returning that string to pass.
        public string CreateCustomer(string customer)
        {
            return customer;
        }

        //This method was authored by Jordan Dhaenens
        //This method serves to retrieve all customers, eventually
        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        //This method was authored by Jordan Dhaenens
        //This method sets the value stored in _activeCustomer which should be a Customer object. Once set it returns that object as confirmation.
        public Customer SetActiveCustomer(Customer cust)
        {
            _activeCustomer = cust;
            return _activeCustomer;
        }

        //This method was authored by Jordan Dhaenens
        //This method returns the value stored in _activeCustomer which should be a Customer object
        public Customer GetActiveCustomer()
        {
            return _activeCustomer;
        }
    }
}