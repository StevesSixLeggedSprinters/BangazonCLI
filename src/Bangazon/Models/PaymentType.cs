using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public double AccountNumber { get; set; }
        public int CustomerId { get; set; }
    }
}