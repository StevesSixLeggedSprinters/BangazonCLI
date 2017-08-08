using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon
{
    /*Authored By Kyle Kellums and Krissy Caron
    This Order Manager class will handle the getting and setting or order data per customer */
    public class OrderManager
    {
       private List<Order> _order = new List<Order>();

       /*Authored By Kyle Kellums and Krissy Caron
       This method is taking the customer id and returning the list of associated orders of that customer.*/
       public List<Order> ListOfCustomerOrders(int custId)
       {
           return _order;
       } 
       /*Authored By Kyle Kellums and Krissy Caron
       This method will determine using the customer id whether a customer has and active order
       Implimentation code will need to be added here to determine the case of it no active order, create a new order,
       or if an active order exsists, use that to add a new product.*/
       public bool CheckForActiveOrder(int custId)
       {
        return true;
       }

       // Authored By Kyle Kellums and Krissy Caron
       // CreateOrder method generates a new order. This new order will be added to the Order table in the database.
       // The CustomerId will be passed in to this method.

       public int CreateOrder(int CustomerId)
       {
            return CustomerId;
       }
    }
}