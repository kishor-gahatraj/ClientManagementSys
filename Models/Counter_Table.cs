using System.ComponentModel.DataAnnotations;
namespace ClientManagementSys.Models
{
    public class Counter_Table

    {
        [Key]
        public int Counter_Id { get; set; }
        public int Total_Organization { get; set; }
        public int Product_Quantity { get; set; }
        public int Total_User { get; set; }

    }
}