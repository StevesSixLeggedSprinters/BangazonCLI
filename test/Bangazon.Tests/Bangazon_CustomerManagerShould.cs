using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class CustomerManagerShould
    {
        
        private CustomerManager _register;

        public CustomerManagerShould()
        {
            _register = new CustomerManager();
            
        }
        
        [Fact]
        public void AddNewCustomer()
        {
            string customer = "Jeremy";
            var person = _register.CreateCustomer(customer); 
            Assert.Equal(person, "Jeremy");
        }

        [Fact]
        public void ListCustomers()
        {
            List<Customer> cust = _register.GetCustomers();
            Assert.IsType<List<CustomerManager>>(cust); 
        }
    }
}
