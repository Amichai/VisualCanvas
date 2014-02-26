using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualCanvas.Models.Library {
    public class Element1 : IVisualNode {
        public List<IVisualBase> Children {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public string ToHtml() {
            return @"<div style=""color:red"">testing</div>";
        }
    }
}