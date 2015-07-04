using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Column : IXmlService
    {
        public string Header { get; set; }
        public int Index { get; set; }
        public IList<Card> Cards { get; set; }

        public Column()
        {
            this.Cards = new List<Card>();
        }

        public System.Xml.Linq.XElement ToXml()
        {
            XElement columnXML = new XElement("column");

            columnXML.Add(new XAttribute("header", this.Header));
            columnXML.Add(new XAttribute("index", this.Index));

            foreach (var card in this.Cards)
            {
                columnXML.Add(card.ToXml());
            }

            return columnXML;
        }

        public void InitializeFromXML(XElement xml)
        {
            this.Header = xml.Attribute("header").Value;
            this.Index = int.Parse(xml.Attribute("index").Value);
            this.Cards.Clear();

            foreach (XElement cardXml in xml.Descendants("card"))
            {
                Card card = new Card();
                card.InitializeFromXML(cardXml);
                this.Cards.Add(card);
            }
        }
    }
}
