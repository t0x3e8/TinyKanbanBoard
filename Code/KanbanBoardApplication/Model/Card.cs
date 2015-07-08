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
        private bool isDirty;

        public string Text
        {
            get { return this.text; }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
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

        public Brush Color
        {
            get { return this.color; }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.isDirty = true;
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
                    this.isDirty = true;
                }
            }
        }

        public bool IsDirty
        {
            get
            {
                if (!this.isDirty)
                {
                    if (this.owner != null)
                        this.isDirty = this.owner.IsDirty;

                    if (!this.isDirty)
                    {
                        foreach (var comment in this.comments)
                        {
                            if (comment.IsDirty)
                            {
                                this.isDirty = true;
                                break;
                            }
                        }
                    }
                }

                return this.isDirty;
            }
            set { this.isDirty = value; }
        }

        public ObservableCollection<Comment> Comments
        {
            get { return this.comments; }
        }

        public Card()
        {
            this.comments = new ObservableCollection<Comment>();
            this.comments.CollectionChanged += (s, e) => { this.isDirty = true; };

            this.isDirty = false;
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

            this.isDirty = true;
        }
    }
}
