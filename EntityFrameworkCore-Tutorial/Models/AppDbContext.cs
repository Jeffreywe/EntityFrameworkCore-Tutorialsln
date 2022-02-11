using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    /// <summary>
    /// this class is used as a support class, it is important to have one of these when using entity framework, this points to other classes to use databases for
    /// if you dont get this right none of this will work with entity framework, 
    /// this class has to inherit from another class to work, dbcontext is apart of the packages we installed onto this project, anything db is the packages we installed
    /// first thing to add to this class, is the list of the classes we want to make into a database table, only the classes we put into here are the only ones 
    /// we can access them from this app, dbset<Customer> references the customer class, do this the same for any other classes you're wanting to use in the table
    /// when we do the capstone project most of the stuff will be added in for us
    /// command line interace, package manager console creates the database and the columns we want, view, other windows, project manager consoles, can use this to get packages for faster access
    /// default project selects what project you want to point to to apply the commands against
    /// migration is a c#class that can be used to create or update databases, gets the information from DbContext and uses this to follow through the commands, only lower case and rarely spaces
    /// to get the database, use, add-migration "Initialization" and hit enter, runs the command 
    /// look at migration before you apply to the database, remove and re-add if need to make changes
    /// to add our database to our c# sql server go to sql server obj exp in view and click on add sql server and select sqlexpress - our database 
    /// efmmigration table in the database tells the framework what to point to when updating or removing
    /// </summary>
    public class AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; } // dbset is referencing Customer to make entity framework work, 
        public virtual DbSet<Order> Orders { get; set; } // when you dont add the class it skips over it and wont bring data back for up or down, have to reference the PUBLIC class you want with DbSet<>
        public virtual DbSet<Item> Items { get; set; } // adds Item class to entity framework to allow use

        public AppDbContext() { } // sets default values
        public AppDbContext(DbContextOptions<AppDbContext> options) // will need this for capstone project not the default one, ALWAYS for entity framework
            : base(options) { } // parent constructor, this configures how thing are going to work, this base calls the parent class and sends it to DbContext to be used

        protected override void OnConfiguring(DbContextOptionsBuilder builder) { // protected is inbetween public and private, protected means that this data is accessible only to the class its defined in like private, but it also is accessible by any classes that inherits this, overrides what onconfigure does with what we do in the body,if we didnt put override in it uses what dbcontext does in the package
            
            if(!builder.IsConfigured) { // if it hasnt been configured goes to body, if it has then skips
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;"); // on my machine look for sqlexpress and thats what i want to use, this is what this statement says, \\ special character that means what comes after this has special meaning, two of them back to back ;database= says what database to access or to create, trusted and connection = true means logs into system and trusts that we are authorized to do what we want in our database, semicolon after everything,
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) { // not always used but in some circumstances
            // makes Code unique, thru fluent api, .Net6 has an attribute for making a column unique
            builder.Entity<Item>( // entity selects class, generic is <> selects Item class,
                e => e.HasIndex(x => x.Code) // HasIndex makes an index,
                        .IsUnique(true)); // IsUnique(true) gets the column to be unique

        }
    }   
}
