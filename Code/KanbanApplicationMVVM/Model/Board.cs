using GalaSoft.MvvmLight;
using KanbanApplicationMVVM.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Model
{
    public class Board : ObservableObject, IXmlService
    {
        #region fields
        private Guid id;
        private string name;
        private DateTime created;
        private ObservableCollection<Column> columns;
        #endregion

        #region properties
        public Guid Id
        {
            get { return this.id; }
            set
            {
                if (this.id == value)
                    return;

                this.id = value;
                this.RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public DateTime Created
        {
            get { return this.created; }
            set
            {
                if (this.created == value)
                    return;

                this.created = value;
                this.RaisePropertyChanged("Created");
            }
        }

        public ObservableCollection<Column> Columns
        {
            get { return this.columns; }
        }
        #endregion

        #region constructors
        public Board()
        {
            this.Id = Guid.NewGuid();
            this.columns = new ObservableCollection<Column>();
        }
        #endregion

        #region methods
        public XElement ToXml()
        {
            XElement boardXML = new XElement("board");
            if (this.Id != null)
                boardXML.Add(new XAttribute("id", this.Id));
            boardXML.Add(new XAttribute("name", this.Name));
            boardXML.Add(new XAttribute("created", this.Created));

            foreach (var column in this.Columns)
            {
                boardXML.Add(column.ToXml());
            }

            return boardXML;
        }
        #endregion
    }
}
