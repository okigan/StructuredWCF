using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace Client.WebMVC3.Controllers {
    public class TechnobabbleController : Controller {

        static ChannelFactory<Web.Contract.ITechnobabble> factory =
            new ChannelFactory<Web.Contract.ITechnobabble>("restendpointname");

        static Web.Contract.ITechnobabble s_technobabble = null;

        [HttpGet]
        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var technobabble = GetChannel();

            var list = technobabble.GetCollection();

            return View(list);
        }

        [HttpGet]
        public ActionResult Details(int id) {
            var technobabble = GetChannel();

            var item = technobabble.Get(id.ToString());

            return View(item);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                var item = new Web.Contract.SampleItem();
                UpdateModel(item);

                var technobable = GetChannel();

                var newItem = technobable.Create(item);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                var technobabble = GetChannel();

                var item = technobabble.Get(id.ToString());
                UpdateModel(item);

                var updatedItem = technobabble.Update(id.ToString(), item);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            //Note: The "Delete" method here seems more of a misnomer as this is more of user 
            //experience as mostly the view logic is different -- hense reusing details logic
            return Details(id);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                var technobabble = GetChannel();

                technobabble.Delete(id.ToString());

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        #region Private methods
        private Web.Contract.ITechnobabble GetChannel() {
            if (null == s_technobabble) {
                s_technobabble = factory.CreateChannel();
            }

            return s_technobabble;
        }
        #endregion
    }
}
