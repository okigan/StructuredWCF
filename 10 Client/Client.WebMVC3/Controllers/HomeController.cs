using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace Client.WebMVC3.Controllers {
    public class HomeController : Controller {

        Web.Contract.ITechnobabble technobabble = null;

        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var factory = new ChannelFactory<Web.Contract.ITechnobabble>("restendpointname");
            technobabble = factory.CreateChannel();

            var list = technobabble.GetCollection();

            return View(list);
        }

        public ActionResult About() {
            return View();
        }
    }
}
