using CodeFirstSampleApp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSampleApp
{
    public class MyContext : DbContext
    {

        public MyContext()
             : base("MydbConn")
        {
            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());

        }

        public DbSet<Employee> Employees { get; set; }

    }
}