using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Models;
using System.Threading.Tasks;
using Bangazon;

namespace Bangazon.Data
{
    //This class serves to populate every table in the database with a few items
    public class DBPopulator
    {
        private SqliteConnection _connection;
        //This method was authored by Jordan Dhaenens
        //This method serves to perform the actual population of the database
        public void Populate()
        {
            _connection = DBInterface.Connection;
        }

        _connection
    }
}