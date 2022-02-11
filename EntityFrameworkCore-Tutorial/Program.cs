using EntityFrameworkCore_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
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

            // add a new order for Kroger
            var kroger = context.Customers.SingleOrDefault(c => c.Name.StartsWith("Krog")); // go thru the customers and find all the names that start with krog, if it finds it then itll bring it back if it doesnt then itll come back null
            var order = new Order() {
                Id = 0, Description = "3rd Order", Total = 2500, CustomerId = kroger.Id
            };
            // add order to list and preps to save change to database
            context.Orders.Add(order);
            context.SaveChanges();

            // read all orders
            var orders = context.Orders.Include(x => x.Customer).ToList(); // include() has to have an argument in it to be valid automatically fills in the primary key and foreign key

            // goes thru each column in the database and returns in the Console with data
            foreach(var o in orders) {
                Console.WriteLine($"{o.Id,-5}{o.Description,-10}"
                                    + $"{o.Total,-10:c} {o.Customer.Name}"); // the o.customer.name returns the name from Customer like a join
            }

            //// delete a customer
            //var amazon = context.Customers.SingleOrDefault(c => c.Name == "Amazon"); // must identify correct row before you can delete using entity framework, if theres more than 1(singleordefault) we'll get an exception, if the default finds none then youll get null

            //if(amazon != null) { // if amazon not equal to null then itll get deleted, if null itll skip
            //    context.Customers.Remove(amazon); // statement to remove selected row
            //    context.SaveChanges();
            //}

            //// update a customer
            //var max = context.Customers.Find(1); // finds primary key 1, max
            //max.Sales += 5000; // adds 5000 to whatever the current sales is for primary key 1 which is max
            //context.SaveChanges(); // entity framework keeps track of our list

            // add a new customer - insert
            //var newCustomer = new Customer() { // creates new customer and inserts data into it, id must be 0 or entityF will think youre updating a customer
            //    Id = 0, Name = "Kroger", Active = true,
            //    Sales = 3000000, Updated = new DateTime(2022, 2, 11)
            //};
            //context.Customers.Add(newCustomer); // adds to collection because entity framework doesnt know about it before we can save
            //context.SaveChanges(); // causes our database to get updated thru entity framework which looks for and identifies new instance and adds to database, function of entity framework, along with insert, update, delete


            // reads all customers
            //List<Customer> customers = context.Customers // makes list from Customers table and converts to list in context, customers
            //                                    .Where(cust => cust.Sales < 100000) // cust represents each customer in our table, looks at Sales column of customers that are less than 100000
            //                                    .ToList();             
            // reads all customers, same as code written above
            //var customers = from cust in context.Customers // downside of query syntax is you cant do aggregate functions, min, max, count, avg, sum, way to use this and method syntax together
                            //where cust.Sales < 100000 // returns all customers
                            //select cust;

            // read customer by primary key
            //var customer = context.Customers.Find(2); // find a customer with a primary key, if it doesnt find what youre looking for itll return null
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");

            //foreach (var customer in customers) { // goes thru the list and pulls customer from customers
            //    Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}"); // lists the customer names pulled in cw string, and Sales formatted to currency
            //}
        }
    }
}
