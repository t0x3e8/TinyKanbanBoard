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
        private int id;
        private string name;
        private DateTime created;
        private ObservableCollection<Column> columns;
        #endregion

        #region properties
        public int Id
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

        public Board()
        {
            this.columns = new ObservableCollection<Column>();
        }

        #region methods
        public System.Xml.Linq.XElement ToXml()
        {
            XElement boardXML = new XElement("board");
            if (this.Id != 0)
                boardXML.Add(new XAttribute("id", this.Id));
            boardXML.Add(new XAttribute("name", this.Name));
            boardXML.Add(new XAttribute("created", this.Created));

            foreach (var column in this.Columns)
            {
                boardXML.Add(column.ToXml());
            }

            return boardXML;
        }

        public void InitializeFromXML(XElement xml)
        {
            this.Id = int.Parse(xml.Attribute("id").Value);
            this.Name = xml.Attribute("name").Value;
            this.Created = DateTime.Parse(xml.Attribute("created").Value);
            this.Columns.Clear();

            foreach (XElement columnXml in xml.Descendants("column"))
            {
                Column column = new Column();
                column.InitializeFromXML(columnXml);
                this.Columns.Add(column);
            }

        }

        public Column FindColumn(Card card)
        {
            var column = this.columns.FirstOrDefault<Column>((c) =>
            {
                return c.Cards.Contains(card);
            });

            return column;
        }
        #endregion
    }
}
