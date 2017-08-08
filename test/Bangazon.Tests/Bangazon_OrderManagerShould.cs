using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class OrderManagerShould
    {  
        private OrderManager _orderList = new OrderManager();

        [Fact]
        public void GetCustomerOrdersList()
        {
            int custId = 4;
            List<Order> custOrderList = _orderList.ListOfCustomerOrders(custId);
            Assert.IsType<List<Order>>(custOrderList);
        }

    }
}
