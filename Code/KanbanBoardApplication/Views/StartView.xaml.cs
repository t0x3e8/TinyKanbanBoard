using KanbanBoardApplication.Model.Database;
using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        public ObservableCollection<BoardEntity> BoardsSet
        {
            get;
            private set;
        }

        public StartView()
        {
            InitializeComponent();
            this.DataContext = this;

            DatabaseContext db = new DatabaseContext();
            this.BoardsSet = new ObservableCollection<BoardEntity>(db.Boards);
        }

        private void CreateNewBoard_Click(object sender, RoutedEventArgs e)
        {
            BoardEntity boardEntity = new BoardEntity() { Created = DateTime.Now, Name = "Board without name" };
            DatabaseContext db = new DatabaseContext();
            boardEntity = db.Boards.Add(boardEntity);
            db.SaveChanges();

            Window window = Window.GetWindow(this);
            var boardView = ViewsLocator.BoardView;
            (boardView as BoardView).Initialize(boardEntity);
            (window as IViewChanger).ChangeView(boardView);
        }

        private void BoardOpen_Click(object sender, RoutedEventArgs e)
        {
            int boardEntityId = (int)(sender as Button).Tag;

            DatabaseContext db = new DatabaseContext();
            BoardEntity boardEntity = db.Boards.SingleOrDefault(s => s.Id == boardEntityId);

            if (boardEntity != null)
            {
                Window window = Window.GetWindow(this);
                var boardView = ViewsLocator.BoardView;
                (boardView as BoardView).Initialize(boardEntity);
                (window as IViewChanger).ChangeView(boardView);
            }

        }
    }
}
