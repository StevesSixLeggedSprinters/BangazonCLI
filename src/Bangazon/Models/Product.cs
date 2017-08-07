using System;
using System.Collections.Generic;



namespace Bangazon.Models
{
  public class Product
  {
    public int ProductId {get; set;}
    public double Price {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime DateProductAdded {get; set;}
    public int CustomerId {get; set;}
    public int Quantity {get; set;}
  }
}