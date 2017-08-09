using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class Order
    {
        public int OrderId {get; set;}
        public DateTime DateOrderCreated = DateTime.Now;
        public DateTime DateOrderPlaced {get; set;}
        public int CustomerId {get; set;}
        public int? PaymentTypeId {get; set;}
     }
}