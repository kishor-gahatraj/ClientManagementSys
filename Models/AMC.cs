
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{

    public class AMC
    {
      
        [Key]
        public int AMC_Id { get; set; }
        //public string AMC_Name { get; set; }  
        public int Maintenance_Charge { get; set; }
        public DateTime Maintenance_Date { get; set; }    
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }
        public virtual Organization Organization { get; set; }

    }
}