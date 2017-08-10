using System;
using System.Collections.Generic;


namespace Bangazon.Models
{
    /* Krissy Caron Authored this Customer Model to set the blueprint for the customer object.
    The Customer Class contains the Key Value Pairs for the customer in the bangazon program 
    Each Customer will have an ID which will be a Primary Key, First Name, Last Name, Email, Phone
    DateAccount Created, whether a users account is active. */ 
  public class Customer 
    {   
        //Primary Key
        public int CustomerId { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Phone {get; set; }
        public DateTime DateAccountCreated = DateTime.Now;

    }
} 