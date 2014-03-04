using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace VisualCanvas.Models {
    public interface IVisualBase {
        string ToHtml();
        void Parse(XElement xml);
        string Style { get; set; }
    }
}