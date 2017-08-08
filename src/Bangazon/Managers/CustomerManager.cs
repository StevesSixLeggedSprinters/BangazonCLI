using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class CustomerManager
    {

        private List<Customer> _customers = new List<Customer>(); 

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
    }
}