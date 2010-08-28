using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Service {
    class Conversion {
        public static Core.Contract.SampleItem ToApp(Web.Contract.SampleItem instance) {
            Core.Contract.SampleItem item = new Core.Contract.SampleItem() {
                Id = instance.Id,
                StringValue = instance.StringValue
            };
            return item;
        }

        public static Web.Contract.SampleItem ToWeb(Core.Contract.SampleItem b) {
            return new Web.Contract.SampleItem() { Id = b.Id, StringValue = b.StringValue };
        }

        public static IList<Web.Contract.SampleItem> ToWeb(IList<Core.Contract.SampleItem> list) {
            IList<Web.Contract.SampleItem> listWeb = new List<Web.Contract.SampleItem>();
            foreach(var b in list) {
                listWeb.Add(ToWeb(b));
            }
            return listWeb;
        }
    }
}
