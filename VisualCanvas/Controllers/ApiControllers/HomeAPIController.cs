using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using VisualCanvas.Models;

namespace VisualCanvas.Controllers.ApiControllers {
    public class HomeAPIController : ApiController {
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id) {
            return "value";
        }

        [HttpPost]
        public string submit(string inputText) {
            try {
                XElement root = XElement.Parse(inputText);
                Assembly a = Assembly.Load("VisualCanvas");
                var t = a.GetType(string.Format("VisualCanvas.Models.Library.{0}", root.Name.ToString()));
                dynamic i = Activator.CreateInstance(t);
                i.Parse(root);
                return i.ToHtml();
            } catch (XmlException ex) {
                return "Failed to parse xml";
            } catch (Exception ex) {
                return ex.Message;
            }
            ///Create objects from each type
            ///Set propeties
            ///Render recursively as HTML (root.ToHtml())
        }
    }
}
