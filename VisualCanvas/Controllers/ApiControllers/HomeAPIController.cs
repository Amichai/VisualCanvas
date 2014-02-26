using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace VisualCanvas.Controllers.ApiControllers {
    public class HomeAPIController : ApiController {
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id) {
            return "value";
        }

        [HttpPost]
        public void submit(string inputText) {
            XElement root = XElement.Parse(inputText);

            ///Create objects from each type
            ///Set propeties
            ///Render recursively as HTML (root.ToHtml())
        }
    }
}
