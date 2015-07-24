using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.ViewModel
{
    public class StartViewModel : ViewModelBase
    {
        private IProjectsRepository dataService;
        private IApplicationContext appContext;
        private IBoardRepository boardRepository;
        private ObservableCollection<Project> projects;

        public ObservableCollection<Project> Projects
        {
            get { return this.projects; }
            private set
            {
                if (this.projects == value)
                    return;

                this.projects = value;
                this.RaisePropertyChanged("Projects");
            }
        }

        public RelayCommand CreateBoardCommand
        {
            get
            {
                return new RelayCommand(() => this.CreateBoardCommandExecute());
            }
        }

        public RelayCommand<Project> OpenProjectCommand
        {
            get
            {
                return new RelayCommand<Project>((cmdParameter) => this.OpenProjectCommandExecution(cmdParameter));
            }
        }
        
        public StartViewModel(IProjectsRepository dataService, IApplicationContext appContext)
        {
            if (dataService == null)
                throw new ArgumentException("IDataService cannot be null.");

            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.dataService = dataService;
            this.appContext = appContext;
            this.Projects = new ObservableCollection<Project>(this.dataService.GetProjects());
        }

        private void CreateBoardCommandExecute()
        {
            this.appContext.ActiveProject = new Project() { Created = DateTime.Now, Name = string.Empty };
            this.appContext.BoardRepository.Initialize(new Board() { Created = DateTime.Now, Name = "New board" });
            this.appContext.ViewModelLocator.BoardViewModel = new BoardViewModel(this.appContext, this.dataService);
            this.appContext.ActiveViewModel = this.appContext.ViewModelLocator.BoardViewModel;
        }


        private void OpenProjectCommandExecution(Project projectToOpen)
        {
            if (projectToOpen == null)
                return;

            this.appContext.ActiveProject = projectToOpen;
            this.appContext.BoardRepository.Initialize(projectToOpen.Xml);
            this.appContext.ViewModelLocator.BoardViewModel = new BoardViewModel(this.appContext, this.dataService);
            this.appContext.ActiveViewModel = this.appContext.ViewModelLocator.BoardViewModel;
        }
    }
}
