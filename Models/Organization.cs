using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Organization
    {
        [Key]
        
        public int Org_Id { get; set; }
        [Required]
        public string Org_Name { get; set; }
        [Required]
        public string Org_Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Org_Contact { get; set; }
        [Required]
        public string Org_Email { get; set; }
        public ICollection<AMC> AMCs { get; set; }
        public ICollection<Invoice> Invoice { get; set; }          
        public IList<ProductOrganization> ProductOrganization { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
        public Org_Representative Org_Representative { get; set; }      
       
    }
}