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
            int customerHasActiveOrder = _orderList.GetActiveOrder(customerId);
            Assert.IsType<int>(customerHasActiveOrder);
        }

        /*  Authored by Kyle Kellums & Krissy Caron
            This method tests if a customer's order gets created.
            CustomerId will be passed to this method
        */
        [Fact]
        public void OrderManagerShouldCreateAnOrder()
        {
            int customerId = 4;
            DateTime orderCreated = DateTime.Now;


            var createANewOrder = _orderList.CreateOrder(customerId, orderCreated);
            Assert.True(createANewOrder != 0);
        }

        [Fact]
        public void IsTheCustomersCartEmpty()
        {

            string someOrderId = "1";
            var checkingTheCart = _orderList.IsCartEmpty(someOrderId);
            Assert.NotNull(someOrderId); 
        }

        [Fact]
        public void ShouldGetOrderTotal()
        {
            Order firstOrder = new Order()
            {
                OrderId = 1,
                DateOrderCreated = DateTime.Now,
                PaymentTypeId = 2
            }


            var totalPricePerOrder = _orderList.OrderTotal(firstOrder.OrderId);
            Assert.True(totalPricePerOrder);
        }


    }
}
