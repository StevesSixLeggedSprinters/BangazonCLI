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

        //Krissy Caron Authored - Construtor for the Customer test class of CustomerManagerShould.
        public CustomerManagerShould()
        {
            //Krissy Caron Authored -This is the new instance of the class we are testing in the program code. 
            _register = new CustomerManager();
            
        }
    
        //Krissy Caron Authored - Use a very specifc naming method here to send the test to the
        // program code to get a return of the type it was sent. 
        [Fact]
        public void AddNewCustomer()
        {
            string firstName = "Jeremy";
            string lastName = "Smith";
            string email = "a@a.com";
            string phone = "55555555555";
            DateTime dateAccountCreated = DateTime.Now;

            int customerId = _register.CreateCustomer(firstName, lastName, email, phone, dateAccountCreated); 
            Assert.NotNull(customerId);
        }

        //This test method was authored by Jordan Dhaenens
        //This test verifies that GetCustomers() works 
        //Krissy Caron Added Clarification-This test verifies that GetCustomers() returns a list of customers, 
        [Fact]
        public void ListCustomers()
        {
            List<Customer> cust = _register.GetCustomers();
            Assert.Empty(cust);
            string firstName = "Jeremy";
            string lastName = "Smith";
            string email = "a@a.com";
            string phone = "55555555555";
            DateTime dateAccountCreated = DateTime.Now;
            int customerId = _register.CreateCustomer(firstName, lastName, email, phone, dateAccountCreated);
            cust = _register.GetCustomers();
            Assert.NotEmpty(cust); 

        }

    }
}
