
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{

    public class AMC
    {
      
        [Key]
        public int AMC_Id { get; set; }
        [Display(Name= "Maintenance")]
        [Required(ErrorMessage = "Please enter Maintance Charge")]
        public int Maintenance_Charge { get; set; }
        [Required(ErrorMessage = "Please enter Maintance Date")]
        public DateTime Maintenance_Date { get; set; }    
        [ForeignKey("Product")]
        //[Required(ErrorMessage = "Please Add Product")]
        public int Product_Id { get; set; }

        public virtual Product Product { get; set; }
        [ForeignKey("Organization")]
        //[Required(ErrorMessage = "Please Add Organization")]
        public int Org_Id { get; set; }
        public virtual Organization Organization { get; set; }

    }
}