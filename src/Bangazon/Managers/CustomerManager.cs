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

        public List<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}