using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    /// <summary>
    /// make sure class is public to properly access this class from the folder in our project
    /// </summary>
    public class Customer {

        // entity framework assumes id, or classnameid, as primary key. if you want something else you have to designate it as primary key
        public int Id { get; set; } // collumns for the entity framework list/collections
        public string Name { get; set; }
        public bool Active { get; set; }
        public decimal Sales { get; set; }
        public DateTime Updated { get; set; } // datetime collumn for dates
    }
}
