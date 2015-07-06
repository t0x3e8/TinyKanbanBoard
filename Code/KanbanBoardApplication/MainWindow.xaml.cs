using KanbanBoardApplication.Model;
using KanbanBoardApplication.Services;
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
using System.Xml.Linq;

namespace KanbanBoardApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewChanger
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ChangeView(ViewsLocator.StartView);
        }

        public void ChangeView(UserControl view)
        {
            this.ContentArea.Content = view;
        }
    }
}
