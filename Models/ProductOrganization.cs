using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class ProductOrganization
    {
     
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }
        public Organization Organization { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }
        //naming
    }
}
