using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

namespace Client.MvcApp.Controllers {
    public class TechnobabbleController : Controller {
        static ChannelFactory<Web.Contract.ITechnobabble> factory =
            new ChannelFactory<Web.Contract.ITechnobabble>("restendpointname");

        Web.Contract.ITechnobabble s_technobabble = null;

        //
        // GET: /Technobabble/
        [HttpGet]
        public ActionResult Index() {
            var technobabble = GetChannel();

            var list = technobabble.GetCollection();

            return View(list);
        }

        //
        // GET: /Technobabble/Details/5
        [HttpGet]
        public ActionResult Details(int id) {
            var technobabble = GetChannel();

            var item = technobabble.Get(id.ToString());

            return View(item);
        }

        //
        // GET: /Technobabble/Create
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Technobabble/Create

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
                var technobabble = GetChannel();

                var item = technobabble.Get(id.ToString());
                UpdateModel(item);

                var updatedItem = technobabble.Update(id.ToString(), item);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Technobabble/Delete/5
        [HttpGet]
        public ActionResult Delete(int id) {
            //Note: The "Delete" method here seems more of a misnomer as this is more of user 
            //experience as mostly the view logic is different -- hense reusing details logic
            return Details(id);
        }

        //
        // POST: /Technobabble/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

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
