using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStatusTracker.Domain
{
    public interface IProjectDataSource
    {
        IQueryable<BugCase> BugCases { get; }
        IQueryable<Project> Projects { get; }
        void Save();
    }
}
