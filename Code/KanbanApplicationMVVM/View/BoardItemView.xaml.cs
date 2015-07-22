using KanbanApplicationMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KanbanApplicationMVVM.View
{
    /// <summary>
    /// Interaction logic for BoardItem.xaml
    /// </summary>
    public partial class BoardItemView : UserControl
    {
        public BoardItemView()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (this.DataContext != null)
                {
                    var ctx = this.DataContext as BoardItemViewModel;
                    if (ctx != null)
                        ctx.EditCardCommand.Execute(null);
                }
            }
        }
    }
}
