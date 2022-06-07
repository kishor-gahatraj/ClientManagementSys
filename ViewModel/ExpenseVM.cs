using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.ViewModel
{
    public class ExpenseVM
    {
        public int Expenses_Id { get; set; }
        public string Expenditure_Name { get; set; }
        public int Expenditure_Price { get; set; }
        public int Total_Price { get; set; }
        public int Org_Id { get; set; }

        [ForeignKey("Product_Id")]
        public int Product_Id { get; set; }
    }
}
