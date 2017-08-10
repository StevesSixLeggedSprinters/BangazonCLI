using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    // This page was authored by Kyle Kellums

    //Class name DatabaseInterface - this will hold our interaction methods for the database and SQL
    public class DatabaseInterface
    {
        private string _connectionString;
        public static SqliteConnection _connection;

        public DatabaseInterface(string database)
        {
            string enVariable = $"{Environment.GetEnvironmentVariable(database)}";
            _connectionString = $"Data Source={enVariable}";
            _connection = new SqliteConnection(_connectionString);
        }

        // 
        public void Query(string command, Action<SqliteDataReader> actionHandler)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();
                dbCommand.CommandText = command;

                using (SqliteDataReader dataReader = dbCommand.ExecuteReader())
                {
                    actionHandler (dataReader);
                }

                dbCommand.Dispose();
                _connection.Close();
            }
        }

        public void Delete(string command)
        {
            using(_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();
                dbCommand.CommandText = command;

                dbCommand.ExecuteNonQuery();

                dbCommand.Dispose();
                _connection.Close();
            }
        }

        public int Insert(string command)
        {
            int insertItemId = 0;

            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();
                dbCommand.CommandText = command;

                dbCommand.ExecuteNonQuery();

                this.Query("select last_insert_rowId()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbCommand.Dispose();
                _connection.Close();
            }

            return insertItemId;
        }

        public void CheckCustomerTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the customer table exists
                dbCommand.CommandText = $"select id from customer";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table customer (
                            'CustomerId'            integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'FirstName'             varchar(80) not null,
                            'LastName'              varchar(80) not null,
                            'Email'                 varchar(80) not null,
                            'Phone'                 varchar(80) not null,
                            'DateAccountCreated'    text NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S'))
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }

        public void CheckProductTypeTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the ProductType table exists
                dbCommand.CommandText = $"select id from ProductType";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table ProductType (
                            'ProductTypeId'       integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'Name'                varchar(80) NOT NULL
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }


        public void CheckProductTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the Product table exists
                dbCommand.CommandText = $"select id from Product";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table Product (
                            'ProductId'         integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'Price'             real NOT NULL,
                            'Title'             varchar(80) NOT NULL,
                            'Description'       varchar(80) NOT NULL,
                            'DateProductAdded'  text NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S')),
                            'Quantity'          integer NOT NULL,
                            'CustomerId'        integer NOT NULL,
                            'ProductTypeId'     integer NOT NULL,
                             FOREIGN KEY('ProductTypeId') REFERENCES 'ProductType'('ProductTypeId'),
                             FOREIGN KEY('CustomerId') REFERENCES 'Customer'('CustomerId')
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }

        public void CheckOrdersTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the Orders table exists
                dbCommand.CommandText = $"select id from Orders";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table Orders (
                            'OrderId'       integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'DateCreated'   text NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S')),
                            'DateOrdered'   text NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S')), 
                            'CustomerId'    integer NOT NULL,
                            'PaymentTypeId' integer NOT NULL,
                            FOREIGN KEY('CustomerId') REFERENCES 'Customer'('CustomerId'),
                            FOREIGN KEY('PaymentTypeId') REFERENCES 'PaymentType'('PaymentTypeId')
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }

        public void CheckPaymentTypeTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the PaymentType table exists
                dbCommand.CommandText = $"select id from PaymentType";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table PaymentType (
                            'PaymentTypeId'      integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'PaymentTypeName'    varchar(80) NOT NULL,
                            'AccountNumber'      integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'CustomerId'         integer NOT NULL,
                            FOREIGN KEY('CustomerId') REFERENCES 'Customer'('CustomerId')
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }

        public void CheckProductOrderTable()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbCommand = _connection.CreateCommand();

                // this checks to see if the ProductOrder table exists
                dbCommand.CommandText = $"select id from ProductOrder";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbCommand.ExecuteReader()) { }
                    dbCommand.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbCommand.CommandText = $@"create table ProductOrder (
                            'ProductOrderId'      integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            'ProductId'           integer NOT NULL,
                            'OrderId'             integer NOT NULL,
                            FOREIGN KEY('ProductId') REFERENCES 'Product'('ProductId'),
                            FOREIGN KEY('OrderId') REFERENCES 'Order'('OrderId'),
                        )";
                        try
                        {
                            dbCommand.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                        dbCommand.Dispose();
                    }
                }
                _connection.Close();

            }
        }
    }
}