using System;
using System.Collections.Generic;
using Bangazon.Models;


namespace Bangazon
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Seed the database if none exists
            // var db = new DatabaseInitializer();
            // db.VerifyDataExists();
            DatabaseInterface db = new DatabaseInterface("BangazonCLI_db");

            ProductTypeManager prodTypeManager = new ProductTypeManager();
            ProductManager prodManager = new ProductManager(db);
            
            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            // If option 1 was chosen, create a new customer account
            if (choice == 1)
            {
                Console.WriteLine ("Enter customer first name");
                Console.Write ("> ");
                string firstName = Console.ReadLine();
                Console.WriteLine ("Enter customer last name");
                Console.Write ("> ");
                string lastName = Console.ReadLine();
                Console.WriteLine ("Enter customer city");
                Console.Write ("> ");
                string city = Console.ReadLine();
                Console.WriteLine ("Enter customer state");
                Console.Write ("> ");
                string state = Console.ReadLine();
                Console.WriteLine ("Enter customer postal code");
                Console.Write ("> ");
                string postalCode = Console.ReadLine();
                Console.WriteLine ("Enter customer phone number");
                Console.Write ("> ");
                string phoneNumber = Console.ReadLine();
                // CustomerManager manager = new CustomerManager();
            }
            //This choice is authored by Jordan Dhaenens
            if (choice == someNumberFromMainMenu)
            {
                Console.Clear();
                Console.WriteLine ("Choose ProductType");
                //display product types and accept input from user to select a type
                List<ProductType> types = prodTypeManager.GetProductTypes();
                foreach (ProductType type in types)
                {
                    Console.WriteLine($"{type.ProductTypeId}. {type.Name}");
                }

                Console.WriteLine(">");
                int prodTypeID = int.Parse(Console.ReadLine());

                //capture product info
                Console.Clear();
                Console.WriteLine("Enter price");
                double price = double.Parse(Console.ReadLine()); 
                Console.WriteLine("Enter title");
                string title = Console.ReadLine();
                Console.WriteLine("Enter description"); 
                string description = Console.ReadLine();
                DateTime date = DateTime.Now;
                Console.WriteLine("Enter quantity to list");
                int quantity = int.Parse(Console.ReadLine());
                //get activeCustomer id
                int custId = manager.ActiveCustomer.CustomerId;
                prodManager.AddProduct(price, title, description, date, quantity, custId, prodTypeID);
            }
        }
    }
}
