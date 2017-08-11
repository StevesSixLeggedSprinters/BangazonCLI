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
            //If Option 2 
            if (choice == 2)
            {
                Console.WriteLine ("Which customer will be active?");
                
                List <Customer> customersList = manager.GetCustomers();
                    foreach (Customer customer in customersList)
                    {
                        Console.WriteLine($"{customer.CustomerId}. {customer.FirstName} {customer.LastName}");
                    } 
            }
        }
    }
}
