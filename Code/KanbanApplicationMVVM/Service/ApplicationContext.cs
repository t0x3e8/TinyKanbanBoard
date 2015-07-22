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
        private Board activeBoard;
        private ViewModelBase activeViewModel;
        private ViewModelLocator viewModelLocator;

        public Board ActiveBoard
        {
            get { return this.activeBoard; }
            set
            {
                if (this.activeBoard == value)
                    return;

                this.activeBoard = value;
                this.RaisePropertyChanged("ActiveBoard");
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

        public ApplicationContext(ViewModelLocator vmLocator)
        {
            if (vmLocator == null)
                throw new ArgumentException("ViewModelLocator cannot be null.");

            this.viewModelLocator = vmLocator;
        }
    }
}
