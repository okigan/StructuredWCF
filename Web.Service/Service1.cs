using System.Collections.Generic;
using System.ServiceModel.Activation;

namespace Web.Service {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    // Uncomment the next line to create a new instance of the service for each call
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // If the service is renamed, remember to update the global.asax.cs file
    // and/or the web.config and/or the corresponding *.svc file
    public class Service1 : Web.Contract.IService1
    {
        Core.Contract.IService1 impl = new Core.Service.Service1();

        #region IService1 methods
        IList<Web.Contract.SampleItem> Web.Contract.IService1.GetCollection() {
            IList<Core.Contract.SampleItem> list = impl.GetCollection();
            return Conversion.ToWeb(list);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Create(Web.Contract.SampleItem instance) {
            var item = impl.Create(Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Get(string id) {
            var item = impl.Get(int.Parse(id));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.IService1.Update(string id, Web.Contract.SampleItem instance) {
            var item = impl.Update(int.Parse(id), Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        void Web.Contract.IService1.Delete(string id) {
            try {
                impl.Delete(int.Parse(id));
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
