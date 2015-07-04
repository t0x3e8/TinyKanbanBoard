using KanbanBoardApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanBoardApplication.Model
{
    public class Comment :IXmlService
    {
        public DateTime Created { get; set; }
        public string Text { get; set; }
        public Author Owner { get; set; }

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
