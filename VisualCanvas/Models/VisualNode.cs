using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualCanvas.Models {
    public interface IVisualNode : IVisualBase {
        List<IVisualBase> Children { get; set; }
    }
}