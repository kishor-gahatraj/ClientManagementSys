using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManagementSys.Models
{

    public class Progress_Report
    {
        [Key]
        [Required]
        public int Report_Id { get; set; }
        [Required]
        public DateTime LastUpdated_Date { get; set; }
        [Required]
        public DateTime Completion_Date { get; set; }
        [Required]
        public string Supervisor { get; set; }
        [Required]
        public string Current_Milestone { get; set; }
        [Required]
        public string Total_Milestone { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }

    }
}