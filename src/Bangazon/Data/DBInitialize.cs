using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Models;
using System.Threading.Tasks;
using Bangazon;

namespace Bangazon.Data
{
    public static class DBPopulator
    {
        public static void Populate(IServiceProvider someServiceProvider)
        {
            using (var context = new BangazonCLIContext(someServiceProvider.GetRequiredService<DBContextOptions<BangazonCLIContext>>()))
            {
                
            }
        }
    }
}