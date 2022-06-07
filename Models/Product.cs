using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public string Category { get; set; }
        public bool Product_Status { get; set; }
       
        public DateTime Product_CompleteDate { get; set; }
      
        public ICollection<Product_Version> Product_Version { get; set; }
       
        public ICollection<Expenses> Expenses { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public AMC AMC { get; set; }
        public IList<ProductOrganization> ProductOrganization { get; set; }
             
        public virtual Progress_Report ReportId { get; set; }

    }
}
