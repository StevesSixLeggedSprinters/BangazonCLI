using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class CustomerManager
    {
        private Customer _activeCustomer = new Customer();

        private List<Customer> _customers = new List<Customer>(); 

        public string CreateCustomer(string customer)
        {
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer SetActiveCustomer(Customer cust)
        {
            _activeCustomer = cust;
            return _activeCustomer;
        }

        public Customer GetActiveCustomer()
        {
            return _activeCustomer;
        }
    }
}