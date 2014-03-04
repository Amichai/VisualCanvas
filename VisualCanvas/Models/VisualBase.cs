using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace VisualCanvas.Models {
    public class VisualBase {
        public VisualBase() {
            this.Style = "";
        }
        public List<IVisualBase> Children { get; set; }

        public void Parse(XElement xml) {
            this.parseAttributes(xml);
            Assembly a = Assembly.Load("VisualCanvas");
            this.Children = new List<IVisualBase>();
            foreach (var e in xml.Elements()) {
                var t = a.GetType(string.Format("VisualCanvas.Models.Library.{0}", e.Name.ToString()));
                dynamic i = Activator.CreateInstance(t);
                i.Parse(e);
                this.Children.Add(i);
            }
        }

        protected void appendStyle(string name, string value) {
            this.Style += string.Format("{0}:{1};", name, value);
        }

        /// <summary>
        /// Parses and appends the attributes: width, margin, padding
        /// TODO: height
        /// </summary>
        protected void parseAttributes(XElement xml) {
            var w = xml.Attribute("Width");
            if (w != null) {
                this.appendStyle("width", w.Value + "px");
            }
            var m = xml.Attribute("Margin");
            if (m != null) {
                this.appendStyle("margin", m.Value + "px");
            }

            var p = xml.Attribute("Padding");
            if (p != null) {
                this.appendStyle("padding", p.Value + "px");
            }

            var h = xml.Attribute("Height");
            if (h != null) {
                this.appendStyle("height", h.Value + "px");
            }
        }

        public string Style { get; set; }
    }
}