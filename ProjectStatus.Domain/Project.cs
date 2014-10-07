using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStatusTracker.Domain
{
    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual ICollection<BugCase> BugCases { get; set; }
    }
}
