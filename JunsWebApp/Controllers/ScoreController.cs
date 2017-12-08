using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunsWebApp.Filters;

namespace JunsWebApp.Controllers
{
    /// <summary>
    /// This class is for Route test, see config in RouteConfig
    /// </summary>
    [Log]
    public class ScoreController : Controller
    {
        // GET: Score
        public ActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Contact", "Home", new {contactPerson = "Junguoguo"});
            if (name.Equals("file"))
                return File(Server.MapPath("../Content/file.txt"),"text");
            if (name.Equals("css"))
                return File(Server.MapPath("../Content/Site.css"), "text/css");
            if (name.Equals("json"))
                return Json(new {RequestFile = name, RequestMessage = "This is a json object to read"},
                    JsonRequestBehavior.AllowGet);
            
            var dic = new Dictionary<string,string>()
            {
                { "loris","109"},
                { "doris","99"},
                { "jun","149"},
                { "fuck","150"},
                { "default","No Entry"}
            };
            var score = dic.ContainsKey(name) ? dic[name] : dic["default"];
            var message = Server.HtmlEncode($"The score of {name} is {score}");
            return Content(message);
        }
    }
}