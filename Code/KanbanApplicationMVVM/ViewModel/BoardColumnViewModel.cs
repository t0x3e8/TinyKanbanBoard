using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KanbanApplicationMVVM.Model;
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
    public class BoardColumnViewModel : ViewModelBase
    {
        #region fields
        private string newCardTitle;
        private IApplicationContext appContext;
        private Column column;
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
            get { return this.column; }
            set
            {
                if (this.column == value)
                    return;

                if (this.column != null)
                    this.column.Cards.CollectionChanged -= CardsCollectionChanged;
                this.column = value;
                this.column.Cards.CollectionChanged += CardsCollectionChanged;

                this.RaisePropertyChanged("Column");
            }
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

        public BoardColumnViewModel(IApplicationContext appContext)
        {
            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.appContext = appContext;
        }

        #region methods
        private void AddNewCardExecuteCommand()
        {
            if (string.IsNullOrWhiteSpace(this.NewCardTitle))
                return; // or notify user about this?

            this.Column.Cards.Add(new Card() { Text = this.NewCardTitle });
            this.NewCardTitle = string.Empty;
        }

        private void CardsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    this.BoardCards = new ObservableCollection<BoardItemViewModel>();
                    foreach (var card in e.NewItems)
                    {
                        this.BoardCards.Add(new BoardItemViewModel(this.appContext) { Card = card as Card});
                    }
                    break;
                case NotifyCollectionChangedAction.Add:
                    foreach (var card in e.NewItems)
                    {
                        this.BoardCards.Add(new BoardItemViewModel(this.appContext) { Card = card as Card });
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
            }
        }
        #endregion
    }
}
