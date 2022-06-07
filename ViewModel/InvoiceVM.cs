namespace ClientManagementSys.ViewModel
{
    public class InvoiceVM
    {
        public int Invoice_Id { get; set; }
        public int Invoice_No { get; set; }

        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }

        public int Product_Id { get; set; }

        public int Org_Id { get; set; }
    }
}
