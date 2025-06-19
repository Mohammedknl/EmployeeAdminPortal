using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;//This package Contains DbContext class 

namespace EmployeeAdminPortal.Data
{
    //Here ApplicationDbContext class inherits from DbContext class which is a part of Microsoft Entity Framework Core
    public class ApplicationDbContext:DbContext

    {
        //Now Creating a constructor for the class by clicking on ApplicationDbContext class and ctrl+. and selecting
        //by passing DbContextOptions as a parameter of type ApplicationDbContext
        //with name as options and passing this options to base class
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

         }

        //Adding a property for the collection we r going to store in to a DB ie Employees table in to Local DB
        public DbSet<Employee> Employees { get; set; }
        //Here DbSet is a property for DB and type as Employee which is our Entity which we created
        //and Employees is the table name in to the Db usually table name we take plural form of an Entity
    }
}
