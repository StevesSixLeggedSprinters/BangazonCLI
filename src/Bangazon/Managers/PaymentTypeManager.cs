using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    // Comments were authored by Kyle Kellums
    // PaymentTypeManager is a class that holds the method 'AddPaymentType()'
    // This class and method gives the user the ability to add a type of payment (e.g. visa, master card, etc.)
    public class PaymentTypeManager
    {
        // The method 'AddPaymentType' enables the user to add a payment type for a customer. Customer and Payment type are passed in.
        // PaymentType is a foreign key for orders.
        // Customer is a foreign key for PaymentType.

        public bool AddPaymentType(Customer cst, PaymentType pmt)
        {
            return true;
        }
    }
}