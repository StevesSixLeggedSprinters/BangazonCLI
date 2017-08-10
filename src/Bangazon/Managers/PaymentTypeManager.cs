using System;
using System.Collections.Generic;
using Bangazon.Models;
using System.Linq;

namespace Bangazon
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _money = new List<PaymentType>();

        // kk - AddPaymentType class is an int type. It
        public int AddPaymentType(PaymentType pmt)
        {
            int payTypeId = 0;
            _money.Add(pmt);
            payTypeId = 3;
            return payTypeId;
        }

        public List<PaymentType> GetPaymentTypes(int custId)
        {
            List<PaymentType> filteredMoney = _money.Where(m => (m.CustomerId == custId)).ToList();
            return filteredMoney;
        }

        public bool SelectPaymentType(int cusId, int payTypeId)
        {
            return true;
        }
    }
}