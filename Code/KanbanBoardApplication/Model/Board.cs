using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Board : IXmlService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public IList<Column> Columns { get; set; }

        public Board()
        {
            this.Columns = new List<Column>();
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
