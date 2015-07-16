using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Card : IXmlService
    {
        private string text;
        private int index;
        private Brush color;
        private Author owner;
        private ObservableCollection<Comment> comments;

        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
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
                }
            }
        }

        public Brush Color
        {
            get { return this.color; }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                }
            }
        }

        public Author Owner
        {
            get { return this.owner; }
            set
            {
                if (this.owner != value)
                {
                    this.owner = value;
                }
            }
        }

        public ObservableCollection<Comment> Comments
        {
            get { return this.comments; }
        }

        public Card()
        {
            this.comments = new ObservableCollection<Comment>();
        }

        public System.Xml.Linq.XElement ToXml()
        {
            XElement cardXML = new XElement("card");

            cardXML.Add(new XAttribute("text", this.Text));
            cardXML.Add(new XAttribute("index", this.Index));
            if (this.Color != null)
                cardXML.Add(new XAttribute("color", this.Color.ToString()));
            if (this.owner != null)
            cardXML.Add(new XAttribute("owner", this.Owner.Id));

            foreach (var comment in this.Comments)
            {
                cardXML.Add(comment.ToXml());
            }

            return cardXML;
        }

        public void InitializeFromXML(XElement xml)
        {
            this.Text = xml.Attribute("text").Value;
            this.Index = int.Parse(xml.Attribute("index").Value);
            //// TODO: missing woner and brush
            this.Comments.Clear();

            foreach (XElement commentXML in xml.Descendants("comment"))
            {
                Comment comment = new Comment();
                comment.InitializeFromXML(commentXML);
                this.Comments.Add(comment);
            }
        }
    }
}
