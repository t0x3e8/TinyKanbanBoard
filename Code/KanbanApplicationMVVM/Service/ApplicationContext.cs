using GalaSoft.MvvmLight;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.Service
{
    public class ApplicationContext : ObservableObject, IApplicationContext
    {
        private Project activeProject;
        private IBoardRepository boardRepository;
        private ViewModelBase activeViewModel;
        private ViewModelLocator viewModelLocator;

        public IBoardRepository BoardRepository
        {
            get { return this.boardRepository; }
            set
            {
                if (this.boardRepository == value)
                    return;

                this.boardRepository = value;
                this.RaisePropertyChanged("BoardRepository");
            }
        }

        public Project ActiveProject
        {
            get { return this.activeProject; }
            set
            {
                if (this.activeProject == value)
                    return;

                this.activeProject = value;
                this.RaisePropertyChanged("ActiveProject");
            }
        }

        public ViewModelBase ActiveViewModel
        {
            get { return this.activeViewModel; }
            set
            {
                if (this.activeViewModel == value)
                    return;

                this.activeViewModel = value;
                this.RaisePropertyChanged("ActiveViewModel");
            }
        }

        public ViewModelLocator ViewModelLocator
        {
            get { return this.viewModelLocator; }
        }

        public ApplicationContext(ViewModelLocator vmLocator, IBoardRepository boardRepository)
        {
            if (vmLocator == null)
                throw new ArgumentException("ViewModelLocator cannot be null.");

            if (boardRepository == null)
                throw new ArgumentException("IBoardRepository cannot be null.");

            this.viewModelLocator = vmLocator;
            this.BoardRepository = boardRepository;
        }
    }
}
