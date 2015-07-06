using KanbanBoardApplication.Model;
using KanbanBoardApplication.Model.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace KanbanBoardApplication.Views
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class BoardView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Board board;
        private string newColumnHeader;

        public Board Board
        {
            set { this.Board = value; }
            get
            {
                if (this.board == null)
                    this.board = new Board();

                return this.board;
            }
        }

        public string NewColumnHeader
        {
            get { return this.newColumnHeader; }
            set
            {
                if (this.newColumnHeader != value)
                {
                    this.newColumnHeader = value;
                    this.NotifyPropertyChanged("NewColumnHeader");
                }
            }
        }

        public BoardView()
        {
            InitializeComponent();

            this.board = TestBoard.GetBoard();

            this.DataContext = this;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NewColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.newColumnHeader))
            {
                this.Board.Columns.Add(new Column() { Header = this.newColumnHeader });
                this.NewColumnHeader = null;
            }
        }

    }
}
