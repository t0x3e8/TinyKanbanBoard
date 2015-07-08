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
    public class Column : IXmlService
    {
        private string header;
        private int index;
        private ObservableCollection<Card> cards;
        private bool isDirty;

        public string Header
        {
            get { return this.header; }
            set
            {
                if (this.header != value)
                {
                    this.header = value;
                    this.isDirty = true;
                }
            }
        }

        public int Index
        {
            get { return this.index; }
            set
            {
                if (this.index != value)
                {
                    this.index = value;
                    this.isDirty = true;
                }
            }
        }

        public ObservableCollection<Card> Cards
        {
            get { return this.cards; }
        }

        public bool IsDirty
        {
            get
            {
                if (!this.isDirty)
                {
                    foreach (var card in cards)
                    {
                        if (card.IsDirty)
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

        public Column()
        {
            this.cards = new ObservableCollection<Card>();
            this.cards.CollectionChanged += cards_CollectionChanged;
        }

        private void cards_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.isDirty = true;
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

            this.isDirty = true;
        }
    }
}
