using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Service
{
    public class ProjectsRepository : IProjectsRepository
    {
        private DatabaseContext dbContext;

        public ProjectsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Project> GetProjects()
        {
            return this.dbContext.Projects.OrderByDescending((p) => p.Created).ToList();
        }

        public void SaveProject(Project project)
        {
            if (project.Id > 0)
                this.dbContext.Entry<Project>(project).State = System.Data.Entity.EntityState.Modified;
            else
                this.dbContext.Entry<Project>(project).State = System.Data.Entity.EntityState.Added;

            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
