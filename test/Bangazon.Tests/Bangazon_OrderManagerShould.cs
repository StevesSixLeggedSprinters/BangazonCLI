using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class OrderManagerShould
    {  
        private OrderManager _orderList;

        [Fact]
        public void GetCustomerOrdersList()
        {
            List<Orders> orderList = _orderList.ListOfCustomerOrders(custId)
            Assert.IsType<List<Orders>>(custId);
        }

    }
}
