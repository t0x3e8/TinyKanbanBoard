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
    public interface IApplicationContext
    {
        Board ActiveBoard { get; set; }
        ViewModelBase ActiveViewModel { get; set; }
        ViewModelLocator ViewModelLocator { get; }
    }
}
