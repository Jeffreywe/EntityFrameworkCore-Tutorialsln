using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// when adding a new migration put something descriptive about the new migration in the ""
/// </summary>
namespace EntityFrameworkCore_Tutorial.Models {
    public class Order {

        public int Id { get; set; } // primary key
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        public int CustomerId { get; set; } // foreign key : if it has another name as a customer in another table (class) and Id at the end of it then the entity framework assigns this property as a foregin key
        public virtual Customer Customer { get; set; } // marking a property as virtual it marks it in the class but not in the table

    }
}
