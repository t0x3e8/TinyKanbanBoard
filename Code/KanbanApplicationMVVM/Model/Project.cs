﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string XmlString { get; set; }

        [NotMapped]
        public XElement Xml
        {
            get
            {
                return XElement.Parse(this.XmlString);
            }
            set
            {
                this.XmlString = value.ToString();
            }
        }
    }
}
