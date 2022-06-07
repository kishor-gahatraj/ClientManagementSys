using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models

{
    public class Org_Representative
    {
        [Key]
        public int Representative_Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Display(Name ="Representative Status")]
        public bool Representative_Status { get; set; }
        public string Representative_Email { get; set; }
        public string Representative_FullName { get; set; }
        public string Representative_Address { get; set; }
       
        public Organization Organization { get; set; }
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }

    }
}