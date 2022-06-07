using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Organization
    {
        [Key]
        public int Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Address { get; set; }  
        [DataType(DataType.PhoneNumber)]
        public long Org_Contact { get; set; }
        public string Org_Email { get; set; }
        public AMC AMC { get; set; }                
        public ICollection<Invoice> Invoice { get; set; }          
        public IList<ProductOrganization> ProductOrganization { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
        public Org_Representative Org_Representative { get; set; }      
       
    }
}