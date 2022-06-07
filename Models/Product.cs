using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public int Product_Price { get; set; }
        [Required]
        public string Category { get; set; }
        public bool Product_Status { get; set; }
        [Required]

        public DateTime Product_CompleteDate { get; set; }
      
        public ICollection<Product_Version> Product_Version { get; set; }
       
        public ICollection<Expenses> Expenses { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<AMC> AMCs { get; set; }
        public IList<ProductOrganization> ProductOrganization { get; set; }
             
        public virtual Progress_Report ReportId { get; set; }

    }
}
