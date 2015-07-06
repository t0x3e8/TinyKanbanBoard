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
        public string Text { get; set; }
        public int Index { get; set; }
        public Brush Color { get; set; }
        public Author Owner { get; set; }
        public ObservableCollection<Comment> Comments { get; set; }

        public Card()
        {
            this.Comments = new ObservableCollection<Comment>();
        }

        public System.Xml.Linq.XElement ToXml()
        {
            XElement cardXML = new XElement("card");

            cardXML.Add(new XAttribute("text", this.Text));
            cardXML.Add(new XAttribute("index", this.Index));
            if (this.Color != null)
                cardXML.Add(new XAttribute("color", this.Color.ToString()));
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
