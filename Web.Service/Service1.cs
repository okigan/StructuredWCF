using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Web.Service {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    // Uncomment the next line to create a new instance of the service for each call
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // If the service is renamed, remember to update the global.asax.cs file
    // and/or the web.config and/or the corresponding *.svc file
    public class TechnobabbleService : Web.Contract.ITechnobabble
    {
        Core.Contract.ITechnobabble impl = null;

        public TechnobabbleService() {
            impl = new Core.Service.TechnobabbleService();
        }

        #region ITechnobabble methods
        IList<Web.Contract.SampleItem> Web.Contract.ITechnobabble.GetCollection() {
            IList<Core.Contract.SampleItem> list = impl.GetCollection();
            return Conversion.ToWeb(list);
        }

        Web.Contract.SampleItem Web.Contract.ITechnobabble.Create(Web.Contract.SampleItem instance) {
            var item = impl.Create(Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.ITechnobabble.Get(string id) {
            var item = impl.Get(int.Parse(id));
            return Conversion.ToWeb(item);
        }

        Web.Contract.SampleItem Web.Contract.ITechnobabble.Update(string id, Web.Contract.SampleItem instance) {
            var item = impl.Update(int.Parse(id), Conversion.ToApp(instance));
            return Conversion.ToWeb(item);
        }

        void Web.Contract.ITechnobabble.Delete(string id) {
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
