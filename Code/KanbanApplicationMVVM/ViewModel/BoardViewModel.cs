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
    public class BoardViewModel : ViewModelBase, IDisposable
    {
        #region fields
        private IApplicationContext appContext;
        private IProjectsRepository dataService;
        private string newColumnTitle;
        private IBoardRepository boardRepository;
        private ObservableCollection<BoardColumnViewModel> boardColumns = new ObservableCollection<BoardColumnViewModel>();
        private CardMessage editCard;
        #endregion

        #region properties
        public CardMessage EditCard
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

        public RelayCommand SaveBoardCommand
        {
            get { return new RelayCommand(() => this.SaveBoardExecuteCommand()); }
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
  
        #region methods
        private void InitializeColumns()
        {
            this.BoardColumns = new ObservableCollection<BoardColumnViewModel>();

            foreach (var column in this.boardRepository.GetColumns())
            {
                this.BoardColumns.Add(new BoardColumnViewModel(this.appContext, this.boardRepository.CreateColumnRepository(column)));
            }
        }

        private void AddNewColumnExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(this.NewColumnTitle))
                return; // or notify user about this?

            this.boardRepository.AddColumn(new Column() { Header = this.NewColumnTitle });
            this.InitializeColumns();
            this.NewColumnTitle = string.Empty;
        }

        private void CloseBoardExecuteCommand()
        {
            this.appContext.ActiveProject = null;
            this.boardRepository.Restart();
            this.appContext.ActiveViewModel = this.appContext.ViewModelLocator.StartViewModel;
        }
        
        private void SaveBoardExecuteCommand()
        {
            this.appContext.ActiveProject.Xml = this.boardRepository.ToXml();
            this.dataService.SaveProject(this.appContext.ActiveProject);
        }

        private void EditCardMessageReceived(CardMessage msgData)
        {
            this.EditCard = msgData;
        }

        public BoardViewModel(IApplicationContext appContext, IProjectsRepository dataService)
        {
            if (dataService == null)
                throw new ArgumentException("IDataService cannot be null.");

            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.dataService = dataService;
            this.appContext = appContext;
            this.boardRepository = appContext.BoardRepository;
            Messenger.Default.Register<CardMessage>(this, "EditCardMessage", (msgData) => this.EditCardMessageReceived(msgData));
            this.InitializeColumns();
        }

        public void Dispose()
        {
            Messenger.Default.Unregister<CardMessage>(this);
        }
        #endregion
    }
}
