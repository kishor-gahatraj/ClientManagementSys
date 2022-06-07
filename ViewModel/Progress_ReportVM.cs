namespace ClientManagementSys.ViewModel
{
    public class Progress_ReportVM
    {
        public int Report_Id { get; set; }
        public DateTime LastUpdated_Date { get; set; }
        public DateTime Completion_Date { get; set; }
        public string Supervisor { get; set; }
        public string Current_Milestone { get; set; }
        public string Total_Milestone { get; set; }
  
        public int Product_Id { get; set; }
    }
}
