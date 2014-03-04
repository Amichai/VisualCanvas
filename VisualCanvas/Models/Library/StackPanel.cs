using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace VisualCanvas.Models.Library {
    public class StackPanel : VisualBase, IVisualNode {
        public string ToHtml() {
            if (!this.Vertical) {
                foreach (var i in Children) {
                    i.Style += "float:left;";
                }
            }
            var inner = string.Concat(Children.Select(i => i.ToHtml()));
            var html = string.Format(@"<div style=""{0}"">{1}</div>", this.Style, inner);
            return html;
        }

        public new void Parse(XElement xml) {
            this.parseAttributes(xml);
            Assembly a = Assembly.Load("VisualCanvas");
            this.Vertical = true;
            this.Children = new List<IVisualBase>();
            if (xml.Attribute("Orientation").Value == "Horizontal") {
                this.Vertical = false;
            }
            foreach (var e in xml.Elements()) {
                var t = a.GetType(string.Format("VisualCanvas.Models.Library.{0}", e.Name.ToString()));
                dynamic i = Activator.CreateInstance(t);
                i.Parse(e);
                this.Children.Add(i);
            }
        }

        public bool Vertical { get; set; }
    }
}