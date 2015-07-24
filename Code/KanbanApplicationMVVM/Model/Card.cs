using GalaSoft.MvvmLight;
using KanbanApplicationMVVM.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Model
{
    public class Card : ObservableObject, IXmlService 
    {
        private string text;
        private int index;
        
        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text == value)
                    return;

                this.text = value;
                this.RaisePropertyChanged("Text");
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

        public Card()
        {
        }

        public Card(XElement xml)
        {
            this.Text = xml.Attribute("text").Value;
            this.Index = int.Parse(xml.Attribute("index").Value);
            //// TODO: missing woner and brush
            //this.Comments.Clear();

            //foreach (XElement commentXML in xml.Descendants("comment"))
            //{
            //    Comment comment = new Comment();
            //    comment.InitializeFromXML(commentXML);
            //    this.Comments.Add(comment);
            //}
        }

        public System.Xml.Linq.XElement ToXml()
        {
            XElement cardXML = new XElement("card");

            cardXML.Add(new XAttribute("text", this.Text));
            cardXML.Add(new XAttribute("index", this.Index));
            //if (this.Color != null)
            //    cardXML.Add(new XAttribute("color", this.Color.ToString()));
            //if (this.owner != null)
            //    cardXML.Add(new XAttribute("owner", this.Owner.Id));

            //foreach (var comment in this.Comments)
            //{
            //    cardXML.Add(comment.ToXml());
            //}

            return cardXML;
        }
    }
}
