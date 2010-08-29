using System.Collections.Generic;
using System.ServiceModel.Activation;

namespace Web.Service {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    // Uncomment the next line to create a new instance of the service for each call
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // If the service is renamed, remember to update the global.asax.cs file
    // and/or the web.config and/or the corresponding *.svc file
    public class Service1Web : Web.Contract.IService1 {
        Core.Contract.IService1 service = new Core.Service.Service1();

        public Service1Web() {
        }

        #region IService1 methods
        IList<Web.Contract.SampleItem> Web.Contract.IService1.GetCollection() {
            IList<Core.Contract.SampleItem> list = service.GetCollection();
            return Conversion.ToWeb(list);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Create(Web.Contract.SampleItem instance) {
            var item = service.Create(Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Get(string id) {
            var item = service.Get(int.Parse(id));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Update(string id, Web.Contract.SampleItem instance) {
            var item = service.Update(int.Parse(id), Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        void Web.Contract.IService1.Delete(string id) {
            try {
                service.Delete(int.Parse(id));
            } catch(KeyNotFoundException ) {
                //HTTP Delete is idempotent, hence delete with key that is no longer found
                //is not an error
                //NOTE: this HTTP/REST concept does not propogate/alter the internal 
                //interface definition/behavior
            }
        }
        #endregion
    }
}
