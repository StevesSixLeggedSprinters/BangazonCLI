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
            _register.CreateCustomer("Jeremy"); 
            Assert.Equal(customer);
        }

        [Fact]
        public void ListCustomers()
        {

        }
    }
}
