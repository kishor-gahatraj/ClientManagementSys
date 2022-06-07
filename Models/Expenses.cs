using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{
    public class Expenses
    {
        //foreign should be added of organization 
        [Key]
        public int Expenses_Id { get; set; }
        public string Expenditure_Name { get; set; }
        public int Expenditure_Price { get; set; }
        public int Total_Price { get; set; }
        public Organization Organization { get; set; }
        [ForeignKey("Organization")]
        public int Org_Id { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }


    }
}