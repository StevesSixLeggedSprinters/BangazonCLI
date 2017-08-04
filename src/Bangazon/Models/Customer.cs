using System;
using System.Collections.Generic;


namespace Bangazon
{
  public class Customer 
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Phone {get; set; }
        public DateTime DateAccountCreated = DateTime.Now;
        public int IsActive {get; set;}
    }
} 