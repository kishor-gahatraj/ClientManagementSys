using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Product_Version
    {
        
     
        [Key]
        [Required]
        public int Product_VersionId { get; set; }
        [Required]
        public DateTime Created_Date { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public DateTime Modified_Date { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }

    }
}