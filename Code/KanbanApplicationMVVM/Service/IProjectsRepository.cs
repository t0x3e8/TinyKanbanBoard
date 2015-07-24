using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Service
{
    public interface IProjectsRepository : IDisposable
    {
        IList<Project> GetProjects();
        void SaveProject(Project project);
    }
}
