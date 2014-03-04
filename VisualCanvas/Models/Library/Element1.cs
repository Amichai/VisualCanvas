using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace VisualCanvas.Models.Library {
    public class Element1 : VisualBase, IVisualNode {

        public string ToHtml() {
            return WebUtility.HtmlEncode(string.Format(@"<div style=""color:red;{0}"">testing</div>", this.Style));
        }
    }
}