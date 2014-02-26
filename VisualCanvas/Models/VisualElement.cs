using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualCanvas.Models {
    public interface IVisualElement : IVisualBase {
        IVisualBase Content { get; set; }
    }
}