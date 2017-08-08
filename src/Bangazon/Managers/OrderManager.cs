using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    public class OrderManager
    {
       private List<Order> _order = new List<Order>();

       public List<Order> ListOfCustomerOrders(int custId)
       {
           return _order;
       } 
    }
}