using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    /// <summary>
    /// make sure class is public to properly access this class from the folder in our project, attributes have []
    /// attributes can be used in classes differently than unit testing
    /// there is an attribute in c# and entity framework that tells SQL to change a value thing
    /// 
    /// </summary>
    public class Customer {

        // entity framework assumes id, or classnameid, as primary key. if you want something else you have to designate it as primary key
        public int Id { get; set; } // collumns for the entity framework list/collections
        [Required] // tells entity framework that name is not nullable when it gets to sql database, this attribute just modifies the one it sits above, refrane from adding required to any datatypes that arent allowed to be null by default
        [StringLength(50)] // attribute tells database to set string length to 50
        public string Name { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "decimal(9,2)")] // changes column to decimal(9,2)
        public decimal Sales { get; set; }
        public DateTime Updated { get; set; } // datetime collumn for dates

    }
}
