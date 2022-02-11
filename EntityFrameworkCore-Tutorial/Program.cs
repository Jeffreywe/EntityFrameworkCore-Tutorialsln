using EntityFrameworkCore_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_Tutorial {
    /// <summary>
    /// This class to Entity Framework, when you do this you have to add software manually, and it doesnt give
    /// us access to SQL database have to enable that by adding packages in
    /// to find, tools, nuget package manager, manage nuget packages for solution, to add the packages 
    /// go to browse and look for specified pakcages, in this case we want the Microsoft.Entity.FrameworkCore packages, .tools and .sqlserver
    /// have to match up package version numbers with .net uses, in our case .Net5, verify installed properly with correct version numbers,
    /// when installing the packages make suree they go into the correct project with the correct .net version, can remove or update packages in the sltn explorer on projects
    /// to reference classes in folders in the project you have to use the namespace and .foldername to access them
    /// same things we did in LINQ we can do thru entity framework, because entity fraemwork identifies them collections
    /// </summary>
    class Program {
        static void Main(string[] args) {

            AppDbContext context = new AppDbContext(); // this is creating an instance of a class, all of our interaction with the database will start with the dbcontext which is from the appdbcontext class

            List<Customer> customers = context.Customers.ToList(); // makes list from Customers table and converts to list in context, customers
            foreach(var customer in customers) { // goes thru the list and pulls customer from customers
                Console.WriteLine($"{customer.Name}"); // lists the customer names pulled in cw string
            }
        }
    }
}
