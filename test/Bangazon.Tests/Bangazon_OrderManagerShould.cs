using System;
using Xunit;
using Bangazon;
using Bangazon.Models;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    /*Authored by Kyle Kellums & Krissy Caron
    This Class OrderManagerShould is Testing the OrderManager */
    public class OrderManagerShould
    {  
        private OrderManager _orderList = new OrderManager();

        /* Authored by Kyle Kellums & Krissy Caron
        This Test Method is getting induvidual customer orders by the customers id.*/
        [Fact]
        public void GetCustomerOrdersList()
        {
            int custId = 4;
            List<Order> custOrderList = _orderList.ListOfCustomerOrders(custId);
            Assert.IsType<List<Order>>(custOrderList);
        }

        // This test method will get a customer's active order by the customer id
        // and determines if the paymentTypeId exists 
        [Fact]
        public void OrderManangerShouldGetCustomersActiveOrder()
        {
            int customerId = 5;
            bool customerHasActiveOrder = _orderList.CheckForActiveOrder(customerId);
            Assert.True(customerHasActiveOrder);
        }

    }
}
