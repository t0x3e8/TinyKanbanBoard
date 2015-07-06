using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KanbanBoardApplication.Services
{
    public interface IViewChanger
    {
        void ChangeView(UserControl view);
    }
}
