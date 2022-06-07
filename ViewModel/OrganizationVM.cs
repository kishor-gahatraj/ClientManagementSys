
using System.ComponentModel.DataAnnotations;

namespace ClientManagementSys.ViewModel
{
    public class OrganizationVM
    {
        public int Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Address { get; set; }
        
        
        [DataType(DataType.PhoneNumber)]

        public long Org_Contact { get; set; }
        public string Org_Email { get; set; }

    }
}
