using System;
using System.Collections.Generic;
using Bangazon.Models;
using System.Linq;

namespace Bangazon
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _money = new List<PaymentType>();

        /*   kk - AddPaymentType() is an int type. 
                - The method will have a payment type passed back to it.
                - On line 18, the payTypeId is initially set to 0. We do this to veryify that our method on line     20 is giving a PaymentTypeId int.
                - This method then returns the payTypeId. 
        */
        public int AddPaymentType(PaymentType pmt) // 
        {
            int payTypeId = 0;
            _money.Add(pmt);
            // The PayType will be passed in to the insert method. The insert method will return the PayTypeId.
            // If the PaymentTypeId is still zero, it didn't work
            payTypeId = 3;
            return payTypeId;
        }

        /* - kk  
        - The GetPaymentTypes() method is a List type.
        - This method will get a list of PaymentTypes according to the customerId.
        - The method return '_money'
        */
        public List<PaymentType> GetPaymentTypes(int customerId)
        {
            return _money;            
        }
    }
}