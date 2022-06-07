using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models

{
    public class Org_Representative
    {
        [Key]
        [Required]
        public int Representative_Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Display(Name ="Representative Status")]
        [Required]
        public bool Representative_Status { get; set; }
        [Required]
        public string Representative_Email { get; set; }
        [Required]
        public string Representative_FullName { get; set; }
        [Required]
        public string Representative_Address { get; set; }
       
        public Organization Organization { get; set; }
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }

    }
}