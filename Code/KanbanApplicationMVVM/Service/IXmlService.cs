﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanbanApplicationMVVM.Service
{
    public interface IXmlService
    {
        XElement ToXml();
        void InitializeFromXML(XElement xml);
    }
}
