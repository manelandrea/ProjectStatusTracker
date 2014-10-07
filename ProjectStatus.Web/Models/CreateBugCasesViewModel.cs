using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectStatusTracker.Web.Models
{
    public class CreateBugCasesViewModel
    {
        [Key]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }

        [Required]
        public string TaskTitle { get; set; }

        public string TaskDetails { get; set; }

        public int PercentStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public int ProjectedNoOfHours { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProjectedCompletionDate { get; set; }

        public int ActualNoOfHours { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

        public string IssuesOrRemarks { get; set; }

        public List<UserProfile> UserProfile { get; set; }

        public string AssignedTo { get; set; }

        public string AssignedBy { get; set; }
    }
}