using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStatusTracker.Domain
{
    public class BugCase
    {
        public virtual int Id { get; set; }
        public virtual string TaskTitle { get; set; }
        public virtual string TaskDetails { get; set; }
        public virtual int PercentStatus { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual int ProjectedNoOfHours { get; set; }
        public virtual DateTime ProjectedCompletionDate { get; set; }
        public virtual int ActualNoOfHours { get; set; }
        public virtual DateTime CompletionDate { get; set; }
        public virtual string IssuesOrRemarks { get; set; }
        public virtual string AssignedTo { get; set; }
        public virtual string AssignedBy { get; set; }
    }
}
