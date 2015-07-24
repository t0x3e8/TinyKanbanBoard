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
        Project ActiveProject { get; set; }
        IBoardRepository BoardRepository { get; set; }
        ViewModelBase ActiveViewModel { get; set; }
        ViewModelLocator ViewModelLocator { get; }
    }
}
