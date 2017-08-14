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
            // Seed the database if none exist

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

            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. Choose active customer");
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
                
            }
        }
    }
}
