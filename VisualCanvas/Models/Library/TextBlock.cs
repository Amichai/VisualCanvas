using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace VisualCanvas.Models.Library {
    public class TextBlock : VisualBase, IVisualNode {
        public string Alignment { get; set; }
        public string Text { get; set; }

        public new void Parse(XElement xml) {
            base.parseAttributes(xml);
            var text = xml.Attribute("Text");
            if (text != null) {
                this.Text = text.Value;
            }

            var alignment = xml.Attribute("HorizontalAlignment");
            if (alignment != null) {
                this.Alignment = alignment.Value;

                if (this.Alignment == "Center") {
                    this.appendStyle("text-align", "center");
                } else if (this.Alignment == "Right") {
                    this.appendStyle("text-align", "right");
                } else if (this.Alignment == "Left") {
                    this.appendStyle("text-align", "left");
                }
            }


            Assembly a = Assembly.Load("VisualCanvas");
            this.Children = new List<IVisualBase>();
            foreach (var e in xml.Elements()) {
                var t = a.GetType(string.Format("VisualCanvas.Models.Library.{0}", e.Name.ToString()));
                dynamic i = Activator.CreateInstance(t);
                i.Parse(e);
                this.Children.Add(i);
            }
        }

        public string ToHtml() {
            return WebUtility.HtmlEncode(string.Format(@"<div style=""{0}"">{1}</div>", this.Style, Text));
        }
    }
}