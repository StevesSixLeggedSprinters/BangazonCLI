using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    // Class PaymentType is an object that holds the entities below (see lines 10-13)
    // This will allow the user to create the PaymentType object
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public double AccountNumber { get; set; }
        public int CustomerId { get; set; }

        // PaymentType method stores data inputed by the user.
        // This method hill create the PaymentType table.
        public PaymentType(Customer cust, double paymentNumber, string payName)
        {
            PaymentTypeName = payName;
            CustomerId = cust.CustomerId;
            AccountNumber = paymentNumber;
        }
    }
}