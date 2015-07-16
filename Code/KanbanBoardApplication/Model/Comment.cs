using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Comment : IXmlService
    {
        private DateTime created;
        private string text;
        private Author owner;

        public DateTime Created
        {
            get { return this.created; }
            set
            {
                if (this.created != value)
                {
                    this.created = value;
                }
            }
        }

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

        public Comment()
        {

        }

        public System.Xml.Linq.XElement ToXml()
        {
            XElement commentXML = new XElement("comment");

            commentXML.Add(new XAttribute("created", this.Created));
            commentXML.Add(new XAttribute("text", this.Text));
            commentXML.Add(new XAttribute("owner", this.Owner.Id));

            return commentXML;
        }

        public void InitializeFromXML(XElement xml)
        {
            this.Created = DateTime.Parse(xml.Attribute("created").Value);
            this.Text = xml.Attribute("text").Value;
            //// TOOD: missing owner
        }
    }
}
