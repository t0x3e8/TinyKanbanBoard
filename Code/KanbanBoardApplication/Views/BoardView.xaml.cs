using KanbanBoardApplication.Model;
using KanbanBoardApplication.Model.Database;
using KanbanBoardApplication.Services;
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
        private BoardEntity boardEntity;
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
        }

        public void Initialize(BoardEntity boardEntity)
        {
            this.boardEntity = boardEntity;
            this.board = new Board() { Name = this.boardEntity.Name, Id = this.boardEntity.Id, Created = this.boardEntity.Created };
            if (!string.IsNullOrEmpty(this.boardEntity.XmlString))
                this.board.InitializeFromXML(this.boardEntity.Xml);

            this.DataContext = this.board;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.board.IsDirty)
            {
                DatabaseContext db = new DatabaseContext();
                this.boardEntity.Xml = this.board.ToXml();
                db.SaveChanges();

                this.board.IsDirty = false;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            (window as IViewChanger).ChangeView(ViewsLocator.StartView);
        }
    }
}
