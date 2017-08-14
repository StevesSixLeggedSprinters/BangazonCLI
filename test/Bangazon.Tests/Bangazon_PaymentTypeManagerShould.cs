using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class PaymentTypeManagerShould
    {
        private PaymentTypeManager _paymentManager;
        public PaymentTypeManagerShould()
        {
            _paymentManager = new PaymentTypeManager();
        }

        /* - kk 
        - AddPaymentTypeForCustomer is a test method for the 'AddPaymentType()' method in PaymentTypeManager.cs
        - A constructor, 'customer' has been created on line 26. It stores a FirstName, LastName, and a CustomerId.
        - 'money' is a constructor that will hold PaymentTypeName, Account Number, and CustomerId.
         */

        [Fact]
        public void AddPaymentTypeForCustomer()
        {
            Customer customer = new Customer()
            {
                FirstName = "John",
                LastName = "Smith",
                CustomerId = 4
            };

            int number = 54632;

            string paymentTypeName = "bitcoin";

            PaymentType money = new PaymentType()
            {
                PaymentTypeName = paymentTypeName,
                AccountNumber = number,
                CustomerId = customer.CustomerId
            };
            int paymentTest = _paymentManager.AddPaymentType(money);
            Assert.True(paymentTest != 0);
        }

        /*
        kk - GetPaymentTypesForCustomer is a test method for 'GetPaymentTypes' in PaymentTypeManager.cs.
        */
        [Fact]
        public void GetPaymentTypesForCustomer()
        {
            Customer joe = new Customer()
            {
                FirstName = "Joe",
                LastName = "Shmoe",
                CustomerId = 1
            };

            PaymentType bitcoin = new PaymentType()
            {
                PaymentTypeName = "bitcoin"
            };

            List<PaymentType> result = _paymentManager.GetPaymentTypes(joe.CustomerId);
            Assert.Empty(result);
            
            _paymentManager.AddPaymentType(bitcoin);

            List<PaymentType> result2 = _paymentManager.GetPaymentTypes(joe.CustomerId);
            Assert.True(result2.Count > 0);
        }
    }
}