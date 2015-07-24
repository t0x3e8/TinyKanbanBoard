using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using KanbanApplicationMVVM.Model;
using KanbanApplicationMVVM.Model.Messenger;
using KanbanApplicationMVVM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApplicationMVVM.ViewModel
{
    public class BoardItemViewModel : ViewModelBase
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
    }
}
