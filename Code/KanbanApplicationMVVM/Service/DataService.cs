using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Service
{
    public class DataService : IDataService
    {
        private DatabaseContext dbContext;

        public DataService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Project> GetProjects()
        {
            return this.dbContext.Projects.OrderByDescending((p) => p.Created).ToList();
        }
    }
}
