using KanbanBoardApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KanbanBoardApplication.Services
{
    public static class ViewsLocator
    {
        public static UserControl BoardView
        {
            get
            {
                return new BoardView();
            }
        }

        public static UserControl StartView
        { get
            {
                return new StartView();
            }
        }
    }
}
