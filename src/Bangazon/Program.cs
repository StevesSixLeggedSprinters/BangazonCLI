using System;
using System.Collections.Generic;
using Bangazon.Data;
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
            MainMenu:
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. Choose active customer");
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
            
            /* Authored by Krissy Caron
            If Option 2 is selected, the list of all customers is displayed to the console in a Numered list. 
            The user can select from the customers which to make active, and that will be stored in the ActiveCustomer. */
            Choice2:
            if (choice == 2)
            {
                Console.WriteLine ("Which customer will be active?");
                
                //Displays List of currently avaiable customers
                List <Customer> customersList = manager.GetCustomers();
                    foreach (Customer customer in customersList)
                    {
                        Console.WriteLine($"{customer.CustomerId}. {customer.FirstName} {customer.LastName}");
                    }
                Console.Write ("> ");
                
                //Takes a string of the chosen customer which is a number, and makes it equal to the instance of that customer in the database.
                string chosenCustomer = Console.ReadLine(); 
                CustomerManager.ActiveCustomer = manager.GetCustomer(int.Parse(chosenCustomer));

                //Takes Active customer and prints their name to console. 
                Console.WriteLine("Active Customer is: " + CustomerManager.ActiveCustomer.FirstName + " " + CustomerManager.ActiveCustomer.LastName);
               goto MainMenu; 
            }

            //This choice is authored by Jordan Dhaenens
            if (choice == 3)
            {
                //Check that there is a customer selected as active
                if (CustomerManager.ActiveCustomer.CustomerId == 0)
                {
                    choice = 2;
                    goto Choice2;
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
                int custId = CustomerManager.ActiveCustomer.CustomerId;

                prodManager.AddProduct(price, title, description, date, quantity, custId, prodTypeID);
            }
        }
    }
}
