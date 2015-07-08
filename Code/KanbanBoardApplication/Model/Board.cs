using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Board : IXmlService
    {
        private int id;
        private string name;
        private DateTime created;
        private ObservableCollection<Column> columns;
        private bool isDirty;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.IsDirty = true;
                }
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.IsDirty = false;
                }
            }
        }

        public DateTime Created
        {
            get { return this.created; }
            set
            {
                if (this.created != value)
                {
                    this.created = value;
                    this.IsDirty = false;
                }
            }
        }

        public ObservableCollection<Column> Columns
        {
            get { return this.columns; }
        }

        public bool IsDirty
        {
            get
            {
                if (!this.isDirty)
                {
                    foreach (var column in this.columns)
                    {
                        if (column.IsDirty)
                        {
                            this.isDirty = true;
                            break;
                        }
                    }
                }
                return this.isDirty;
            }
            set { this.isDirty = value; }
        }

        public Board()
        {
            this.columns = new ObservableCollection<Column>();
            this.columns.CollectionChanged += columns_CollectionChanged;
            this.IsDirty = false;
        }

        private void columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.IsDirty = true;
        }

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
    }
}
