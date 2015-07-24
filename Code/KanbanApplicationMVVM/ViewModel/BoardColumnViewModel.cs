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
    public class BoardColumnViewModel : ViewModelBase, IDisposable
    {
        #region fields
        private string newCardTitle;
        private IApplicationContext appContext;
        private IColumnRepository columnRepository;
        private ObservableCollection<BoardItemViewModel> boardCards= new ObservableCollection<BoardItemViewModel>();
        #endregion

        #region properties
        public string NewCardTitle
        {
            get { return this.newCardTitle; }
            set
            {
                if (this.newCardTitle == value)
                    return;

                this.newCardTitle = value;
                this.RaisePropertyChanged("NewCardTitle");
            }
        }

        public Column Column
        {
            get { return this.columnRepository.Column; }
        }
        
        public ObservableCollection<BoardItemViewModel> BoardCards
        {
            get { return this.boardCards; }
            private set
            {
                if (this.boardCards == value)
                    return;

                this.boardCards = value;
                this.RaisePropertyChanged("BoardCards");
            }
        }

        public RelayCommand AddCardCommand
        {
            get { return new RelayCommand(() => this.AddNewCardExecuteCommand()); }
        }
        #endregion

        public BoardColumnViewModel(IApplicationContext appContext, IColumnRepository columnRepository)
        {
            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");
            if (columnRepository == null)
                throw new ArgumentException("IColumnRepository cannot be null.");

            this.appContext = appContext;
            this.columnRepository = columnRepository;
            Messenger.Default.Register<CardMessage>(this, "RemoveCardMessage", (msgData) => this.RemoveCardMessageReceived(msgData));

            this.InitializeCards();
        }

        public void Dispose()
        {
            Messenger.Default.Unregister<CardMessage>(this);
        }

        #region methods
        private void AddNewCardExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(this.NewCardTitle))
                return; // or notify user about this?

            this.columnRepository.AddCard(new Card() { Text = this.NewCardTitle });
            this.InitializeCards();
            this.NewCardTitle = string.Empty;
        }

        private void InitializeCards()
        {
            this.BoardCards = new ObservableCollection<BoardItemViewModel>();

            foreach (var card in this.columnRepository.GetCards())
            {
                this.BoardCards.Add(new BoardItemViewModel(this.appContext) { Card = card });
            }
        }

        private void RemoveCardMessageReceived(CardMessage msgData)
        {
            this.columnRepository.RemoveCard(msgData.Card);
            this.InitializeCards();
        }
        #endregion
    }
}
