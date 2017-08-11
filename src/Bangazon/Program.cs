using System;
using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

namespace Bangazon
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Seed the database if none exists
            // var db = new DatabaseInitializer();
            // db.VerifyDataExists();

            /* Authored by Krissy Caron this creating a new instance of db and creating the folowing tables
            usign the DatabaseInterface.cs as a blue print. */
            DatabaseInterface db = new DatabaseInterface("BangazonCLI_db");
            db.CheckCustomerTable();
            db.CheckProductTypeTable();
            db.CheckProductTable();
            db.CheckPaymentTypeTable();
            db.CheckOrdersTable();
            db.CheckProductOrderTable();

            // Why does this not need an instance of class DBPopulator?
            DBPopulator.Populate(db);
            
            //Instance of customer manager. 
            CustomerManager manager = new CustomerManager(db);
            ProductTypeManager prodTypeManager = new ProductTypeManager(db);
            ProductManager prodManager = new ProductManager(db);
  
            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("3. Add product to customer profile");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            /* Authored By Krissy Caron
            If option 1 was chosen, create a new customer account will trigger the following in the CMD line.
            A new instance of customer will then be created from each type the user inputs and sent to the db in to the correct columns and table. */
            if (choice == 1)
            {
                Console.WriteLine ("Enter customer first name");
                Console.Write ("> ");
                string firstName = Console.ReadLine();
                Console.WriteLine ("Enter customer last name");
                Console.Write ("> ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter customer email");
                Console.Write(">");
                string email = Console.ReadLine();
                Console.WriteLine ("Enter customer phone number");
                Console.Write ("> ");
                string phoneNumber = Console.ReadLine();

                manager.CreateCustomer(firstName, lastName, email, phoneNumber, DateTime.Now);
            }
            //This choice is authored by Jordan Dhaenens
            if (choice == 3)
            {
                //Check that there is a customer selected as active
                if (CustomerManager.ActiveCustomerId == 0)
                {
                    choice = 2;
                }
                Console.Clear();
                Console.WriteLine ("Choose ProductType");
                //display product types and accept input from user to select a type
                List<ProductType> types = prodTypeManager.GetProductTypes();
                foreach (ProductType type in types)
                {
                    Console.WriteLine($"{type.ProductTypeId}. {type.Name}");
                }
                //Capture ProductTypeId
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
                int custId = CustomerManager.ActiveCustomerId;

                prodManager.AddProduct(price, title, description, date, quantity, custId, prodTypeID);
            }
        }
    }
}
