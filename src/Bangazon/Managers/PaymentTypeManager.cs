using System;
using System.Collections.Generic;
using Bangazon.Models;
using System.Linq;

namespace Bangazon
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _money = new List<PaymentType>();

        public PaymentType AddPaymentType(Customer cst, PaymentType pmt)
        {
            _money.Add(pmt);
            return pmt;
        }

        public List<PaymentType> GetPaymentTypes(int custId)
        {
            List<PaymentType> filteredMoney = _money.Where(m => (m.CustomerId == custId)).ToList();
            return filteredMoney;
        }
    }
}