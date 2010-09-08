using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace Client.WebApp {
    public class Proxy {
        Web.Contract.ITechnobabble proxy = null;

        public Proxy() {
            var factory = new ChannelFactory<Web.Contract.ITechnobabble>("restendpointname");
            proxy = factory.CreateChannel();
        }

        public IList<Web.Contract.SampleItem> GetCollection() {
            var collection = proxy.GetCollection();
            return collection;
        }

        public Web.Contract.SampleItem Create(Web.Contract.SampleItem instance) {
            return proxy.Create(instance);
        }

        public Web.Contract.SampleItem Get(string id) {
            return proxy.Get(id);
        }

        public void Update(Web.Contract.SampleItem instance) {
            var updatedItem = proxy.Update(instance.Id.ToString(), instance);
        }

        public void Delete(Web.Contract.SampleItem instance) {
            proxy.Delete(instance.Id.ToString());
        }
    }
}