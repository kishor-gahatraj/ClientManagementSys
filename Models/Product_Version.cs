using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Product_Version
    {
        
     
        [Key]
        public int Product_VersionId { get; set; }
       
        public DateTime Created_Date { get; set; }
        public string Version { get; set; }
        public DateTime Modified_Date { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }

    }
}