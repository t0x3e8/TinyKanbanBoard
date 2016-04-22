using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.Model.Behaviors;
using KanbanApplicationMVVM.Model.Messenger;
using KanbanApplicationMVVM.Service;
using System;


namespace KanbanApplicationMVVM.ViewModel
{
    public class BoardItemViewModel : ViewModelBase, ICardDragable
    {
        #region fields
        private IApplicationContext appContext;
        private Card card;
        #endregion

        #region properties
        public Card Card
        {
            get { return this.card; }
            set
            {
                if (this.card == value)
                    return;

                this.card = value;
                this.RaisePropertyChanged("Card");
            }
        }

        public RelayCommand RemoveCardCommand
        {
            get { return new RelayCommand(() => this.RemoveCardExecuteCommand()); }
        }

        public RelayCommand EditCardCommand
        {
            get { return new RelayCommand(() => this.EditCardExecuteCommand()); }
        }
        #endregion

        public BoardItemViewModel(IApplicationContext appContext)
        {
            if (appContext == null)
                throw new ArgumentException("IApplicationContext cannot be null.");

            this.appContext = appContext;
        }

        #region methods
        private void EditCardExecuteCommand()
        {
            var message = new CardMessage() { Card = this.Card };
            message.ParentColumn = this.appContext.BoardRepository.FindColumn(this.Card);
            Messenger.Default.Send<CardMessage>(message, "EditCardMessage");
        }

        private void RemoveCardExecuteCommand()
        {
            Messenger.Default.Send<CardMessage>(new CardMessage() { Card = this.card }, "RemoveCardMessage");
        }

        #endregion
        
        public Card DragObject
        {
            get { return this.Card; }
        }

        public void RemoveDragCard(Card card)
        {
            if (card != null)
            {
                Messenger.Default.Send<CardMessage>(new CardMessage() { Card = card }, "RemoveCardMessage");
            }
        }

        public Type Type
        {
            get { return typeof(BoardItemViewModel);}
        }
    }
}
