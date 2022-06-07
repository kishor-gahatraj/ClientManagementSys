
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Invoice
    {
       
        [Key]
        public int Invoice_Id { get; set; }
        public int Invoice_No { get; set; }

        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
      
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }


        public Organization Organization { get; set; }
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }
    }
}