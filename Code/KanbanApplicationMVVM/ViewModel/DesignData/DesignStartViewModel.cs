using GalaSoft.MvvmLight;
using KanbanApplicationMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.ViewModel.DesignData
{
    public class DesignStartViewModel
    {
        public List<Project> Projects
        {
            get
            {
                var projects = new List<Project>();
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                projects.Add(new Project() { Id = 1, Name = "board 1", Created = DateTime.Now });
                projects.Add(new Project() { Id = 4, Name = "board 2", Created = DateTime.Now });
                projects.Add(new Project() { Id = 2, Name = "board 3", Created = DateTime.Now });
                return projects;
            }
        }

        public DesignStartViewModel()
        {
        }
    }
}
