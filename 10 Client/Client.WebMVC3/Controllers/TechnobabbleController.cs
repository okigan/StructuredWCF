using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace Client.WebMVC3.Controllers {
    public class TechnobabbleController : Controller {

        ChannelFactory<Web.Contract.ITechnobabble> factory =
            new ChannelFactory<Web.Contract.ITechnobabble>("restendpointname");

        static Web.Contract.ITechnobabble s_technobabble = null;

        // GET: /Technobabble/

        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            Web.Contract.ITechnobabble technobabble = NewMethod();

            var list = technobabble.GetCollection();

            return View(list);

        }

        //
        // GET: /Technobabble/Details/5

        public ActionResult Details(int id) {
            Web.Contract.ITechnobabble technobabble = NewMethod();

            var item = technobabble.Get(id.ToString());

            return View(item);
        }

        //
        // GET: /Technobabble/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Technobabble/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Technobabble/Edit/5

        public ActionResult Edit(int id) {
            return View();
        }

        //
        // POST: /Technobabble/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Technobabble/Delete/5

        public ActionResult Delete(int id) {
            //Note: The "Delete" method here seems more of misnomer as this is more of user experience
            //as mostly the view logic is different -- hense reusing details logic
            return Details(id);
        }

        //
        // POST: /Technobabble/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                Web.Contract.ITechnobabble technobabble = NewMethod();

                technobabble.Delete(id.ToString());

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        #region Private methods
        private Web.Contract.ITechnobabble NewMethod() {
            if (null == s_technobabble) {
                s_technobabble = factory.CreateChannel();
            }

            return s_technobabble;
        }
        #endregion

    }
}
