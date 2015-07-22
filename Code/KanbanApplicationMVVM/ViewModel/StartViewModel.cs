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
        private IDataService dataService;
        private IApplicationContext appContext;

        public ObservableCollection<Project> Projects { get; set; }

        public RelayCommand CreateBoardCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.appContext.ActiveBoard = new Board() { Created = DateTime.Now };
                    this.appContext.ActiveViewModel = this.appContext.ViewModelLocator.BoardViewModel;
                });
            }
        }

        public StartViewModel(IDataService dataService, IApplicationContext appContext)
        {
            if (dataService == null)
                throw new ArgumentException("IDataService cannot be null.");

            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.dataService = dataService;
            this.appContext = appContext;
            this.Projects = new ObservableCollection<Project>(this.dataService.GetProjects());

        }
    }
}
