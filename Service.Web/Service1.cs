using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Service {
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    // and/or the web.config and/or the corresponding *.svc file
    public class Service1Web : Contract.Web.IService1 {
        Contract.IService1 service = new Service1();

        public Service1Web() {
        }

        #region IService1 methods
        IList<Contract.Web.SampleItem> Contract.Web.IService1.GetCollection() {
            IList<Contract.SampleItem> list = service.GetCollection();
            IList<Contract.Web.SampleItem> listWeb = new List<Contract.Web.SampleItem>();
            foreach(var b in list) {
                listWeb.Add(new Contract.Web.SampleItem() { Id = b.Id, StringValue = b.StringValue });
            }
            return listWeb;

        }

        Contract.Web.SampleItem Contract.Web.IService1.Create(Contract.Web.SampleItem instance) {
            Contract.SampleItem item = new Contract.SampleItem(){
                Id = instance.Id,
                StringValue = instance.StringValue
            };
            service.Create(item);
            return instance;
        }

        Contract.Web.SampleItem Contract.Web.IService1.Get(int id) {
            Contract.SampleItem item = service.Get(id);

            Contract.Web.SampleItem itemWeb = new Contract.Web.SampleItem() {
                Id = item.Id,
                StringValue = item.StringValue
            };

            return itemWeb;
        }

        Contract.Web.SampleItem Contract.Web.IService1.Update(int id, Contract.Web.SampleItem instance) {
            Contract.SampleItem item = ToApp(instance);

            service.Update(id, item);

            return instance;
        }

        private static Contract.SampleItem ToApp(Contract.Web.SampleItem instance) {
            Contract.SampleItem item = new Contract.SampleItem() {
                Id = instance.Id,
                StringValue = instance.StringValue
            };
            return item;
        }

        void Contract.Web.IService1.Delete(int id) {
            service.Delete(id);
        }
        #endregion
    }
}
