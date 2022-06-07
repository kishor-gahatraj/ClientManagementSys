using System.ComponentModel.DataAnnotations;

namespace ClientManagementSys.ViewModel
{
    public class Org_RepresentativeVM
    {
        public int Representative_Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        public bool Representative_Status { get; set; }
        public string Representative_Email { get; set; }
        public string Representative_FullName { get; set; }
        public string Representative_Address { get; set; }
        public int Org_Id { get; set; }
    }
}
