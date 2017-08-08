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

        //This test method was authored by Jordan Dhaenens
        //This test verifies that GetCustomers() works 
        [Fact]
        public void ListCustomers()
        {
            List<Customer> cust = _register.GetCustomers();
            Assert.IsType<List<Customer>>(cust);
        }

        //This test method was authored by Jordan Dhaenens
        //This test verifies that user can set active customer
        [Fact]
        public void SetACustomerAsActive()
        {
            Customer joe = new Customer()
            {
                FirstName = "Joe",
                LastName = "Person",
                CustomerId = 4
            };

            var rez = _register.SetActiveCustomer(joe);
            Assert.Equal(rez, joe);
        }

        //This test method was authored by Jordan Dhaenens
        //This test verifies that user can retrieve the active customer
        [Fact]
        public void RetrieveActiveCustomerFromDB()
        {
            Customer joe = new Customer()
            {
                FirstName = "Joe",
                LastName = "Person",
                CustomerId = 4
            };
            _register.SetActiveCustomer(joe);
            Customer rez = _register.GetActiveCustomer();
            // Assert.IsType<Customer>(rez);
            Assert.Equal(rez, joe);
        }
    }
}
