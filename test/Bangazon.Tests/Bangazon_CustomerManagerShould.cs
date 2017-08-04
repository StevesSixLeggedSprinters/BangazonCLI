using System;
using Xunit;

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

        }
    }
}
