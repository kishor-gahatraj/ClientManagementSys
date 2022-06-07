using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{

    public class Progress_Report
    {
        [Key]
        public int Report_Id { get; set; }
        public DateTime LastUpdated_Date { get; set; }
        public DateTime Completion_Date { get; set; }
        public string Supervisor { get; set; }
        public string Current_Milestone { get; set; }
        public string Total_Milestone { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }

    }
}