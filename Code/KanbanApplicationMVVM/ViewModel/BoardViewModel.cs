using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.Model.Messenger;
using KanbanApplicationMVVM.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        #region fields
        private IApplicationContext appContext;
        private Board board;
        private string newColumnTitle;
        private ObservableCollection<BoardColumnViewModel> boardColumns = new ObservableCollection<BoardColumnViewModel>();
        private EditCardMessage editCard;
        #endregion

        #region properties
        public EditCardMessage EditCard
        {
            get { return this.editCard; }
            set
            {
                if (this.editCard == value)
                    return;

                this.editCard = value;
                this.RaisePropertyChanged("EditCard");
            }
        }

        public string NewColumnTitle
        {
            get { return this.newColumnTitle; }
            set
            {
                if (this.newColumnTitle == value)
                    return;

                this.newColumnTitle = value;
                this.RaisePropertyChanged("NewColumnTitle");
            }
        }

        public Board Board
        {
            get { return this.board; }
            set
            {
                if (this.board == value)
                    return;

                this.board = value;
                this.RaisePropertyChanged("Board");
            }
        }

        public ObservableCollection<BoardColumnViewModel> BoardColumns
        {
            get { return this.boardColumns; }
            private set
            {
                if (this.boardColumns == value)
                    return;

                this.boardColumns = value;
                this.RaisePropertyChanged("BoardColumns");
            }
        }

        public RelayCommand CloseBoardCommand
        {
            get { return new RelayCommand(() => this.CloseBoardExecuteCommand()); }
        }
        
        public RelayCommand CloseEditCardCommand
        {
            get { return new RelayCommand(() => this.EditCard = null); }
        }

        public RelayCommand AddColumnCommand
        {
            get { return new RelayCommand(() => this.AddNewColumnExecuteCommand()); }
        }
        #endregion

        public BoardViewModel(IApplicationContext appContext)
        {
            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.appContext = appContext;
            Messenger.Default.Register<EditCardMessage>(this, (msgData) => this.EditCardMessageReceived(msgData));
            this.board = this.appContext.ActiveBoard;
            this.board.Columns.CollectionChanged += ColumnsCollectionChanged;
        }
        
        #region methods
        private void AddNewColumnExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(this.NewColumnTitle))
                return; // or notify user about this?

            this.appContext.ActiveBoard.Columns.Add(new Column() { Header = this.NewColumnTitle });
            this.NewColumnTitle = string.Empty;
        }

        private void CloseBoardExecuteCommand()
        {
            this.appContext.ActiveBoard = null;
            this.appContext.ActiveViewModel = this.appContext.ViewModelLocator.StartViewModel;
        }

        private void InitializeColumns()
        {
            this.BoardColumns = new ObservableCollection<BoardColumnViewModel>();

            foreach (var column in this.board.Columns)
            {
                this.BoardColumns.Add(new BoardColumnViewModel(this.appContext) { Column = column });
            }
        }

        private void EditCardMessageReceived(EditCardMessage msgData)
        {
            this.EditCard = msgData;
        }

        private void ColumnsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    this.BoardColumns = new ObservableCollection<BoardColumnViewModel>();
                    foreach (var column in e.NewItems)
                    {
                        this.boardColumns.Add(new BoardColumnViewModel(this.appContext) { Column = column as Column });
                    }
                    break;
                case NotifyCollectionChangedAction.Add:
                    foreach (var column in e.NewItems)
                    {
                        this.boardColumns.Add(new BoardColumnViewModel(this.appContext) { Column = column as Column });
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    //foreach (var column in e.NewItems)
                    //{
                    //}
                    break;
            }
        }
        #endregion
    }
}
