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

            PaymentType money = new PaymentType(customer, number, paymentTypeName);
            PaymentType paymentTest = _paymentManager.AddPaymentType(customer, money);
            Assert.Equal(money, paymentTest);
        }

        [Fact]
        public void GetPaymentTypesForCustomer()
        {
            Customer joe = new Customer()
            {
                FirstName = "Joe",
                LastName = "Shmoe",
                CustomerId = 1
            };

            PaymentType bitcoin = new PaymentType(joe, 156156, "bitcoin");
          

            _paymentManager.AddPaymentType(joe, bitcoin);

            List<PaymentType> result = _paymentManager.GetPaymentTypes(joe.CustomerId);

            foreach (PaymentType res in result)
            {
                Assert.Equal(res.CustomerId, joe.CustomerId);
            }
        }
    }
}