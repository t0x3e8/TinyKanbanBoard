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
    public class Column : ObservableObject, IXmlService
    {
        private string header;
        private int index;
        private ObservableCollection<Card> cards;

        public string Header
        {
            get { return this.header; }
            set
            {
                if (this.header == value)
                    return;

                this.header = value;
                this.RaisePropertyChanged("Header");
            }
        }

        public int Index
        {
            get { return this.index; }
            set
            {
                if (this.index == value)
                    return;

                this.index = value;
                this.RaisePropertyChanged("Index");
            }
        }

        public ObservableCollection<Card> Cards
        {
            get { return this.cards; }
        }

        public Column()
        {
            this.cards = new ObservableCollection<Card>();
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
