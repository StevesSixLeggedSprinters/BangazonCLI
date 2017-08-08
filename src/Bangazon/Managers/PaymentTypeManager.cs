using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class PaymentTypeManager
    {
        public bool AddPaymentType(Customer cst, PaymentType pmt)
        {
            return true;
        }

        public List <PaymentType> GetPaymentTypes(int custId)
        {
            List<PaymentType> results = new List<PaymentType>();
            return results;
        }
    }
}