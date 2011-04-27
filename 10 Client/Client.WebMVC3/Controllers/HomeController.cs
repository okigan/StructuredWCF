using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace Client.WebMVC3.Controllers {
    public class HomeController : Controller {


        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            return View();
        }
    }
}
